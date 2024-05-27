// Copyright (c) 2024 DarkNaku
// MIT License

using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DarkNaku.Number
{
    [Serializable]
    public struct Number : IEquatable<Number>, IComparable<Number>
    {
        public static readonly Number Zero = new Number();
        public static readonly Number One = new Number(1, 0);

        private static readonly string[] MAGNITUDES = new string[] { "", "K", "M", "B", "T" };
        private static readonly int BASE_CHAR = Convert.ToInt32('A');
        private static readonly string NUMBER_PATTERN = @"-*\d+\.?\d*[a-zA-Z]{0,2}";
        private static readonly string EXPONENT_PATTERN = @"[a-zA-Z]{1,2}";

        public double Value => _value;
        public uint Exponent => _exponent;

        [SerializeField] public double _value;
        [SerializeField] public uint _exponent;

        public Number(double value, uint exponent = 0)
        {
            _value = value;
            _exponent = exponent;

            Align();
        }
        
        public Number(Number source)
        {
            _value = source.Value;
            _exponent = source.Exponent;

            Align();
        }
        
        public Number(string stringNumber)
        {
            _value = 0d;
            _exponent = 0;

            if (string.IsNullOrEmpty(stringNumber))
            {
                Debug.LogError("[Number] Constructor : String is null or empty.");
                return;
            }

            var match = Regex.Match(stringNumber, NUMBER_PATTERN);

            if (match.Success)
            {
                var exponentString = Regex.Match(match.Value, EXPONENT_PATTERN);

                if (exponentString.Success)
                {
                    if (double.TryParse(match.Value[..^exponentString.Value.Length], out _value))
                    {
                        _exponent = ConvertToExponent(exponentString.Value);
                        
                        Align();
                    }
                }
                else
                {
                    if (double.TryParse(match.Value, out _value))
                    {
                        _exponent = 0;
                        
                        Align();
                    }
                }
            }

            uint ConvertToExponent(string exponentString)
            {
                if (string.IsNullOrEmpty(exponentString))
                {
                    Debug.LogError("[Number] ExponentStringToInt : String is null or empty.");
                    return 0;
                }

                exponentString = exponentString.ToUpper();

                if (exponentString.Length == 2)
                {
                    var firstOffset = Convert.ToInt32(exponentString[0]) - BASE_CHAR;
                    var secondOffset = Convert.ToInt32(exponentString[1]) - BASE_CHAR;

                    return (uint)((firstOffset * 26) + secondOffset + MAGNITUDES.Length);
                }
                
                if (exponentString.Length == 1)
                {
                    for (uint i = 0; i < MAGNITUDES.Length; i++)
                    {
                        if (exponentString == MAGNITUDES[i])
                        {
                            return i;
                        }
                    }
                }

                return 0;
            }
        }

        public bool Equals(Number other)
        {
            other.Align(_exponent);

            return _exponent == other.Exponent && _value.CompareTo(other.Value) == 0;
        }

        public int CompareTo(Number other)
        {
            other.Align(_exponent);
            
            if (_value < 0 && other.Value > 0) return -1;
            if (_value > 0 && other.Value < 0) return 1;

            if (_value < 0 && other.Value < 0)
            {
                if (_exponent > other.Exponent) return -1;
                if (_exponent < other.Exponent) return 1;
                
                return _value.CompareTo(other.Value);
            }
            
            if (_exponent > other.Exponent) return 1;
            if (_exponent < other.Exponent) return -1;
                
            return _value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            if (_exponent < MAGNITUDES.Length)
            {
                if (_exponent == 0)
                {
                    return $"{Math.Floor(_value * 100) * 0.01d:0.##}";
                }
                else
                {
                    return $"{Math.Floor(_value * 100) * 0.01d:0.##}{MAGNITUDES[_exponent]}";
                }
            }
            else
            {
                var magnitude = _exponent - MAGNITUDES.Length;
                var secondOffset = magnitude % 26;
                var firstOffset = magnitude / 26;
                
                return $"{Math.Floor(_value * 100) * 0.01d:0.##}{Convert.ToChar(BASE_CHAR + firstOffset)}{Convert.ToChar(BASE_CHAR + secondOffset)}";
            }
        }
    
        private void Align()
        {
            var isNegative = _value < 0;

            _value = Math.Abs(_value);
        
            while (_value < 1f && _exponent > 0)
            {
                _value *= 1000d;
                _exponent--;
            }
            
            while (_value >= 1000d)
            {
                _value *= 0.001d;
                _exponent++;
            }
            
            if (isNegative)
            {
                _value *= -1;
            }
        }
        
        private void Align(uint toExponent)
        {
            while (_exponent < toExponent)
            {
                _value *= 0.001d;
                _exponent++;
            }
        }

        private static void Align(ref Number a, ref Number b)
        {
            if (a.Exponent > b.Exponent)
            {
                b.Align(a.Exponent);
            }
            else if (b.Exponent > a.Exponent)
            {
                a.Align(b.Exponent);
            }
        }
        
        public static bool operator == (Number a, Number b) => a.Equals(b);

        public static bool operator != (Number a, Number b) => !a.Equals(b);

        public static bool operator < (Number a, Number b)
        {
            Align(ref a, ref b);

            if (a.Exponent == b.Exponent)
            {
                return a.Value < b.Value;
            }

            if (a.Value < 0 && b.Value < 0) return a.Exponent > b.Exponent;
            if (a.Value < 0 && b.Value > 0) return true;
            if (a.Value > 0 && b.Value < 0) return false;
            
            return a.Exponent < b.Exponent;
        }

        public static bool operator > (Number a, Number b)
        {
            Align(ref a, ref b);

            if (a.Exponent == b.Exponent)
            {
                return a.Value > b.Value;
            }
            
            if (a.Value < 0 && b.Value < 0) return a.Exponent < b.Exponent;
            if (a.Value < 0 && b.Value > 0) return false;
            if (a.Value > 0 && b.Value < 0) return true;
            
            return a.Exponent > b.Exponent;
        }

        public static bool operator <= (Number a, Number b)
        {
            Align(ref a, ref b);

            if (a.Exponent == b.Exponent)
            {
                return a.Value <= b.Value;
            }
            
            if (a.Value < 0 && b.Value < 0) return a.Exponent > b.Exponent;
            if (a.Value < 0 && b.Value > 0) return true;
            if (a.Value > 0 && b.Value < 0) return false;
            
            return a.Exponent < b.Exponent;
        }

        public static bool operator >= (Number a, Number b)
        {
            Align(ref a, ref b);

            if (a.Exponent == b.Exponent)
            {
                return a.Value >= b.Value;
            }
            
            if (a.Value < 0 && b.Value < 0) return a.Exponent < b.Exponent;
            if (a.Value < 0 && b.Value > 0) return false;
            if (a.Value > 0 && b.Value < 0) return true;
            
            return a.Exponent > b.Exponent;
        }
        
        public static Number operator - (Number a) => new Number(a.Value * -1, a.Exponent);

        public static Number operator + (Number a, Number b)
        {
            Align(ref a, ref b);

            return new Number(a.Value + b.Value, a.Exponent);
        }

        public static Number operator - (Number a, Number b)
        {
            Align(ref a, ref b);

            return new Number(a.Value - b.Value, a.Exponent);
        }

        public static Number operator * (Number a, Number b)
        {
            return new Number(a.Value * b.Value, a.Exponent + b.Exponent);
        }

        public static Number operator / (Number a, Number b)
        {
            return new Number(a.Value / b.Value, a.Exponent - b.Exponent);
        }

        public static Number operator ++ (Number a)
        {
            return new Number(a.Value + 1d, a.Exponent);
        }

        public static Number operator -- (Number a)
        {
            return new Number(a.Value - 1d, a.Exponent);
        }
        
        public static implicit operator Number(int i) => new Number(i, 0);
        public static implicit operator Number(long l) => new Number(l, 0);
        public static implicit operator Number(float f) => new Number(f, 0);
        public static implicit operator Number(double d) => new Number(d, 0);
        public static implicit operator int(Number n) => Convert.ToInt32(n.Value * Mathf.Pow(1000, n.Exponent));
        public static implicit operator long(Number n) => Convert.ToInt64(n.Value * Mathf.Pow(1000, n.Exponent));
        public static implicit operator float(Number n) => Convert.ToSingle(n.Value * Mathf.Pow(1000, n.Exponent));
        public static implicit operator double(Number n) => Convert.ToDouble(n.Value * Mathf.Pow(1000, n.Exponent));
    }
}