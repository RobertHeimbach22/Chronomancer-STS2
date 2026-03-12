#!/usr/bin/env python3
"""
generate_gdpc_pck.py — Creates a valid Godot 4 GDPC-format PCK file for the
ChronomancerMod, matching the binary structure of SpireModTheAlest.pck.

This produces an empty PCK (file_count=0, flags=2, Godot 4.5.1) that the STS2
mod loader expects alongside the DLL.

Usage:  python3 generate_gdpc_pck.py [output_path]
Default output: ChronomancerMod.pck
"""

import struct
import sys
import os

GODOT_MAJOR   = 4
GODOT_MINOR   = 5
GODOT_PATCH   = 1
PCK_VERSION   = 3      # Godot 4+ format
FLAGS         = 2      # PACK_REL_FILEBASE — file offsets relative to file_base
FILE_BASE     = 112    # 0x70 — start of file data section (right after header)
FILE_COUNT    = 0      # No assets packed; C# logic lives in the DLL

def write_pck(output_path: str) -> None:
    with open(output_path, "wb") as f:
        # --- GDPC magic ---
        f.write(b"GDPC")

        # PCK version and Godot version
        f.write(struct.pack("<I", PCK_VERSION))
        f.write(struct.pack("<I", GODOT_MAJOR))
        f.write(struct.pack("<I", GODOT_MINOR))
        f.write(struct.pack("<I", GODOT_PATCH))

        # Flags  (uint32) + file_base (uint64)
        f.write(struct.pack("<I", FLAGS))
        f.write(struct.pack("<Q", FILE_BASE))

        # 16 reserved uint32 words (64 bytes total reserved block)
        # Header so far: 4+4+4+4+4 = 20 bytes, file_base=8 bytes → 28 bytes
        # We need to reach 0x60 (96 bytes) before file_count
        # 96 - 28 = 68 bytes → but flags+file_base already takes 12 bytes
        # Recalculate:
        # magic(4) + ver(4) + maj(4) + min(4) + patch(4) = 20
        # flags(4) + file_base(8) = 12   → total so far: 32
        # Reserved must pad to offset 0x60 = 96  → need 96 - 32 = 64 more bytes = 16 uint32
        f.write(b"\x00" * 64)   # 16 × 4-byte reserved words

        # file_count
        f.write(struct.pack("<I", FILE_COUNT))

        # No file entries — file_count is 0.
        # The STS2 loader reads C# classes from the DLL directly.

    print(f"[OK] Created GDPC PCK: {output_path}")
    print(f"     Magic   : GDPC")
    print(f"     Version : {PCK_VERSION} (Godot {GODOT_MAJOR}.{GODOT_MINOR}.{GODOT_PATCH})")
    print(f"     Flags   : {FLAGS}")
    print(f"     Files   : {FILE_COUNT}")
    print(f"     Size    : {os.path.getsize(output_path)} bytes")


if __name__ == "__main__":
    out = sys.argv[1] if len(sys.argv) > 1 else "ChronomancerMod.pck"
    write_pck(out)
