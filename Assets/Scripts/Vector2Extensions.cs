    using UnityEngine;

    public static class Vector2Extensions {
        public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0) {
            return new Vector2(vector2.x + x, vector2.y + y);
        }
        
        public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null) {
            return new Vector2(x ?? vector2.x, y ?? vector2.y);
        }
        
        public static bool InRangeOf(this Vector2 current, Vector2 target, float range) {
            return (current - target).sqrMagnitude <= range * range;
        }
        
        public static Vector2 RandomPointInAnnulus(this Vector2 origin, float minRadius, float maxRadius) {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            
            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);
            
            Vector2 position = direction * distance;
            return origin + position;
        }
    }