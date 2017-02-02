using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Syngine.Input
{
	/// <summary>
	/// 
	/// </summary>
	public struct InputState : IEquatable<InputState>
	{
	    public bool Equals(InputState other)
	    {
	        return _isNotDefault == other._isNotDefault
                && _mouseState.Equals(other._mouseState)
                && _touchState.Equals(other._touchState)
                && _keyboardState.Equals(other._keyboardState)
                && GamePadState.Equals(other.GamePadState);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj))
	        {
	            return false;
	        }

	        return obj is InputState && Equals((InputState) obj);
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            var hashCode = _mouseState.GetHashCode();
	            hashCode = (hashCode*397) ^ _isNotDefault.GetHashCode();
	            hashCode = (hashCode*397) ^ _touchState.GetHashCode();
	            hashCode = (hashCode*397) ^ _keyboardState.GetHashCode();
	            hashCode = (hashCode*397) ^ _gamePadState.GetHashCode();
	            return hashCode;
	        }
	    }

		private bool _isNotDefault;
	    private MouseState _mouseState;
		private TouchCollection _touchState;
		private KeyboardState _keyboardState;
        private GamePadState _gamePadState;

        /// <summary>
        /// 
        /// </summary>
        public MouseState MouseState
		{
			get
			{
				return _mouseState;
			}
			internal set
			{
				if (_isNotDefault)
				{
					_isNotDefault = false;
				}

				_mouseState = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public TouchCollection TouchState
		{
			get
			{
				return _touchState;
			}
			internal set
			{
				if (_isNotDefault)
				{
					_isNotDefault = false;
				}

				_touchState = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public KeyboardState KeyboardState
		{
			get
			{
				return _keyboardState;
			}
			internal set
			{
				if (_isNotDefault)
				{
					_isNotDefault = false;
				}

				_keyboardState = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public GamePadState GamePadState
        {
            get
            {
                return _gamePadState;
            }
            internal set
            {
                if (_isNotDefault)
                {
                    _isNotDefault = false;
                }

                _gamePadState = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator ==(InputState a, InputState b)
		{
			return !(a != b);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static bool operator !=(InputState a, InputState b)
		{
			return a.Equals(b);
		}

		public bool IsDefault()
		{
			return !_isNotDefault;
		}
	}
}