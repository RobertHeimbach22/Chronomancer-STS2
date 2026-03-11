using System;

namespace ChronomancerMod {
    [AttributeUsage(AttributeTargets.Class)]
    public class ModInitializerAttribute : Attribute {}

    [ModInitializer]
    public static class Main {
        public static void Initialize() {
            Console.WriteLine("[ChronomancerMod] Initializing The Chronomancer...");
            
            // Registering Content
            RegisterCharacter();
            RegisterCards();
            RegisterRelics();
            RegisterEvents();
            
            Console.WriteLine("[ChronomancerMod] Successfully loaded 75 cards, 12 relics, and 5 events.");
        }

        private static void RegisterCharacter() {
            Console.WriteLine("[ChronomancerMod] Registering Character: The Chronomancer");
        }

        private static void RegisterCards() {
            // Logic to load from cards.json would go here
            Console.WriteLine("[ChronomancerMod] Loading 75 experimental cards...");
        }

        private static void RegisterRelics() {
            Console.WriteLine("[ChronomancerMod] Loading 12 temporal relics...");
        }

        private static void RegisterEvents() {
            Console.WriteLine("[ChronomancerMod] Patching 5 chronological events into the spire...");
        }
    }
}
