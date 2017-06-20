﻿using Windows.Data.Json;

namespace LottieUWP
{
    internal class ShapeTrimPath
    {
        internal enum Type
        {
            Simultaneously = 1,
            Individually = 2
        }

        private readonly Type _type;
        private readonly AnimatableFloatValue _start;
        private readonly AnimatableFloatValue _end;
        private readonly AnimatableFloatValue _offset;

        private ShapeTrimPath(string name, Type type, AnimatableFloatValue start, AnimatableFloatValue end, AnimatableFloatValue offset)
        {
            Name = name;
            _type = type;
            _start = start;
            _end = end;
            _offset = offset;
        }

        internal static class Factory
        {
            internal static ShapeTrimPath NewInstance(JsonObject json, LottieComposition composition)
            {
                return new ShapeTrimPath(json.GetNamedString("nm"), (Type)(int)json.GetNamedNumber("m", 1), AnimatableFloatValue.Factory.NewInstance(json.GetNamedObject("s"), composition, false), AnimatableFloatValue.Factory.NewInstance(json.GetNamedObject("e"), composition, false), AnimatableFloatValue.Factory.NewInstance(json.GetNamedObject("o"), composition, false));
            }
        }

        internal virtual string Name { get; }

        internal new virtual Type GetType()
        {
            return _type;
        }

        internal virtual AnimatableFloatValue End => _end;

        internal virtual AnimatableFloatValue Start => _start;

        internal virtual AnimatableFloatValue Offset => _offset;

        public override string ToString()
        {
            return "Trim Path: {start: " + _start + ", end: " + _end + ", offset: " + _offset + "}";
        }
    }
}