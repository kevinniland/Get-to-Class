using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities {
    public class ParentUtils {
        public const string ENEMY_PARENT = "EnemyParent";
        public const string GROUND_PARENT = "GroundParent";
        public const string LOCKER_PARENT = "LockerParent";

        // Gets the enemy parent object
        public static GameObject GetEnemyParent() {
            return GetParent(ENEMY_PARENT);
        }

        // Gets the ground parent object
        public static GameObject GetGroundParent() {
            return GetParent(GROUND_PARENT);
        }

        // Gets the locker parent object
        public static GameObject GetLockerParent() {
            return GetParent(LOCKER_PARENT);
        }

        // Gets the parent of the object
        private static GameObject GetParent(string parentName) {
            // Find the parent of the object with the name passed in
            var parent = GameObject.Find(parentName);

            // If not found, create an empty game object using the name passed in
            if (!parent) {
                parent = new GameObject("parentName");
            }

            // Return this object
            return parent;
        }
    }
}
