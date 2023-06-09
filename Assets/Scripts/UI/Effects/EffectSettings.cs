using UnityEngine;

namespace UI.Effects
{
    public abstract class EffectSettings : ScriptableObject, IEffectSettings
    {
        public abstract EffectSettings GetEffectSettings ();
    }
}