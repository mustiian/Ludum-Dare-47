using UnityEngine;

namespace Utility
{
    public static class TransformExtension
    {
        public static Transform Copy(this Transform to, Transform from)
        {
            to.position = from.position;
            to.rotation = from.rotation;
            to.localScale = to.parent == null ? from.localScale : to.parent.InverseTransformVector(from.lossyScale);
            return to;
        }
    }
}