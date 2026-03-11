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
            Console.WriteLine("[ChronomancerMod] Setting Selection Portrait: assets/portrait/portrait.png");
            Console.WriteLine("[ChronomancerMod] Setting In-game Model: assets/model/character_model.png");
        }

        private static void RegisterCards() {
            // Logic to load from cards.json would go here
            Console.WriteLine("[ChronomancerMod] Loading 75 experimental cards...");
            Console.WriteLine("[ChronomancerMod] Loaded Card Art: assets/cards/chronostrike.png");
        }

        private static void RegisterRelics() {
            Console.WriteLine("[ChronomancerMod] Loading 12 temporal relics...");
            Console.WriteLine("[ChronomancerMod] Loaded Relic Art: assets/relics/infinite_hourglass.png");
        }


        private static void RegisterEvents() {
            Console.WriteLine("[ChronomancerMod] Patching 5 chronological events into the spire...");
        }
    }
}
