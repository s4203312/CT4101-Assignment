using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasesClass
{

    private const float easeElasticConst = (2f * Mathf.PI) / 3f;
    private const float easeInOutElasticConst = (2f * Mathf.PI) / 4.5f;
    private const float easeOutBounceConst1 = 7.5625f;
    private const float easeOutBounceConst2 = 2.75f;


    public class Powers{
        public static float Linear(float t, float c){
            return t * c;
        }
        public class Quadratic{
            public static float In(float t, float c)
            {
                return t * t * c;
            }
            public static float Out(float t, float c){
                return t * (2f - t) * c;
            }
            public static float InOut(float t, float c){
                if ((t *= 2f) < 1f) return 0.5f * t * t * c;
                return -0.5f * ((t -= 1f) * (t - 2f) - 1f) * c;
            }
            public static float Bezier(float t, float c){
                return 2 * t * (1 - t) + t * t * c;
            }
        }
        public class Cubic{
            public static float In(float t){
                return t * t * t;
            }
            public static float Out(float t){
                return 1 - Mathf.Pow(1 - t, 3);
            }
            public static float InOut(float t){
                if(t < 0.5) return 4 * t * t * t;
                return 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
            }
        }
        public class Quartic{
            public static float In(float t){
                return t * t * t * t;
            }
            public static float Out(float t){
                return 1 - Mathf.Pow(1 - t, 4);
            }
            public static float InOut(float t){
                if(t < 0.5) return 8 * t * t * t * t;
                return 1 - Mathf.Pow(-2 * t + 2, 4) / 2;
            }
        }
        public class Quintic{
            public static float In(float t){
                return t * t * t * t * t;
            }
            public static float Out(float t){
                return 1 - Mathf.Pow(1 - t, 5);
            }
            public static float InOut(float t){
                if(t < 0.5) return 16 * t * t * t * t;
                return 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
            }
        }
    }
    public class Trigonometric{
        public class Sin{
            public static float In(float t){
                return 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
            }
            public static float Out(float t){
                return Mathf.Sin(t * Mathf.PI * 0.5f);
            }
            public static float InOut(float t){
                if ((t *= 2f) < 1f) return 0.5f * (1f - Mathf.Cos(t * Mathf.PI * 0.5f));
                return -0.5f * (Mathf.Sin((t -1) * Mathf.PI * 0.5f));
            }
        }
        public class Cos{
            public static float In(float t){
                return 1f - Mathf.Sin(t * Mathf.PI * 0.5f);
            }
            public static float Out(float t){
                return Mathf.Cos(t * Mathf.PI * 0.5f);
            }
            public static float InOut(float t){
                if ((t *= 2f) < 1f) return 0.5f * (1f - Mathf.Sin(t * Mathf.PI * 0.5f));
                return -0.5f * (Mathf.Cos((t -1) * Mathf.PI * 0.5f));
            }
        }
    }
    public class Exponential{
        public static float In(float t){
            if(t == 0) return 0;
            return Mathf.Pow(2, 10 * t - 10);
        }
        public static float Out(float t){
            if(t == 1) return 1; 
            return 1 - Mathf.Pow(2, -10 * t);
        }
        public static float InOut(float t){
            if(t == 0) return 0;
            if(t == 1) return 1;
            if(t < 0.5) return Mathf.Pow(2, 20 * t - 10) / 2;
            return (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
        }
    }
    public class Circular{
        public static float In(float t){
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
        }
        public static float Out(float t){
            return Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
        }
        public static float InOut(float t){
            if(t < 0.5) return (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2;
            return (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
        }
   }

    public class Elastic{
        public static float In(float t){
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10f - 10.75f) * easeElasticConst);
        }

        public static float Out(float t){
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            return Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10f - 0.75f) * easeElasticConst) + 1;
        }

        public static float InOut(float t){
            if (t == 0) return 0f;
            if (t == 1) return 1f;
            if (t < 0.5f) return -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20f * t - 11.125f) * easeInOutElasticConst)) / 2;
            return (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20f * t - 11.125f) * easeInOutElasticConst)) / 2 + 1;
        }
    }
    public class Bounce{
        public static float In(float t){
            return 1 - Out(1 - t);
        }
        public static float Out(float t){
            if (t < 1 / easeOutBounceConst2) return easeOutBounceConst1 * t * t;
            if (t < 2 / easeOutBounceConst2) return easeOutBounceConst1 * (t -= 1.5f / easeOutBounceConst2) * t + 0.75f;
            if (t < 2.5 / easeOutBounceConst2) return easeOutBounceConst1 * (t -= 2.25f / easeOutBounceConst2) * t + 0.9375f;
            return easeOutBounceConst1 * (t -= 2.625f / easeOutBounceConst2) * t + 0.984375f;
            
        }
        public static float InOut(float t){
            if(t < 0.5) return (1 - Out(1 - 2 * t)) / 2;
            return(1 + Out(2 * t - 1)) / 2;
        }
    }
}