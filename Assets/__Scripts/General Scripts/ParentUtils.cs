using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities {
    public class ParentUtils {
        public const string ENEMY_PARENT = "EnemyParent";

        public static GameObject GetEnemyParent() {
            return GetParent(ENEMY_PARENT);
        }

        private static GameObject GetParent(string parentName) {
            var parent = GameObject.Find(parentName);

            if (!parent) {

            }

            return parent;
        }
    }
}
