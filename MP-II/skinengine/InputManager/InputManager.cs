﻿#region Copyright (C) 2007-2008 Team MediaPortal

/*
    Copyright (C) 2007-2008 Team MediaPortal
    http://www.team-mediaportal.com
 
    This file is part of MediaPortal II

    MediaPortal II is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal II is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal II.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using MediaPortal.Core.InputManager;
using SkinEngine.Controls;

namespace SkinEngine
{
  public class InputManager : IInputManager
  {
    #region events

    private List<Key> _registeredKeys;
    public event MouseMoveHandler OnMouseMove;
    public event KeyPressedHandler OnKeyPressed;
    private bool _needRawKeyboarData;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="InputManager"/> class.
    /// </summary>
    public InputManager()
    {
      _needRawKeyboarData = false;
      _registeredKeys = new List<Key>();
      _registeredKeys.Add(Key.ContextMenu);
      _registeredKeys.Add(Key.Down);
      _registeredKeys.Add(Key.DvdDown);
      _registeredKeys.Add(Key.DvdLeft);
      _registeredKeys.Add(Key.DvdMenu);
      _registeredKeys.Add(Key.DvdRight);
      _registeredKeys.Add(Key.DvdSelect);
      _registeredKeys.Add(Key.DvdUp);
      _registeredKeys.Add(Key.End);
      _registeredKeys.Add(Key.Enter);
      _registeredKeys.Add(Key.Home);
      _registeredKeys.Add(Key.Left);
      _registeredKeys.Add(Key.None);
      _registeredKeys.Add(Key.PageDown);
      _registeredKeys.Add(Key.PageUp);
      _registeredKeys.Add(Key.Right);
      _registeredKeys.Add(Key.Up);
      _registeredKeys.Add(Key.ZoomMode);
      _registeredKeys.Add(Key.Space);
    }

    public void Reset()
    {
      OnMouseMove = null;
      OnKeyPressed = null;
    }

    /// <summary>
    /// returns all registered keys.
    /// </summary>
    /// <value>The keys.</value>
    public List<Key> Keys
    {
      get { return _registeredKeys; }
    }

    /// <summary>
    /// called by window when a mouse move is detected
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public void MouseMove(float x, float y)
    {
      SkinContext.HandlingInput = true;
      SkinContext.MouseUsed = true;
      if (OnMouseMove != null)
      {
        OnMouseMove(x, y);
      }
      SkinContext.HandlingInput = false;
      SkinContext.ScreenSaverActive = false;
    }

    /// <summary>
    /// called by window when a keypress has been received
    /// </summary>
    /// <param name="key">The key.</param>
    public void KeyPressed(Key key)
    {
      SkinContext.HandlingInput = true;
      if (OnKeyPressed != null)
      {
        OnKeyPressed(ref key);
      }

      SkinContext.HandlingInput = false;
      SkinContext.ScreenSaverActive = false;
    }

    /// <summary>
    /// Called by the skin when it wants to press a key
    /// </summary>
    /// <param name="keyChar">string containing the key name.</param>
    public void PressKey(string keyChar)
    {
      SkinContext.HandlingInput = true;
      SkinContext.ScreenSaverActive = false;
      foreach (Key key in Keys)
      {
        if (String.Compare(keyChar, key.Name, true) == 0)
        {
          Key k = key;
          if (OnKeyPressed != null)
          {
            OnKeyPressed(ref k);
          }
        }
      }
    }
#if NOTUSEDANYMORE
    /// <summary>
    /// Predicts which control should get the focus
    /// </summary>
    /// <param name="focusedControl">The current focused control.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static Control PredictFocus(Control focusedControl, ref Key key)
    {
      if (key == Key.Up)
      {
        return PredictFocusUp(focusedControl, ref key, true);
      }
      if (key == Key.Down)
      {
        return PredictFocusDown(focusedControl, ref key, true);
      }
      if (key == Key.Left)
      {
        return PredictFocusLeft(focusedControl, ref key, true);
      }
      if (key == Key.Right)
      {
        return PredictFocusRight(focusedControl, ref key, true);
      }

      return null;
    }

    /// <summary>
    /// returns the distance between 2 controls
    /// </summary>
    /// <param name="c1">The c1.</param>
    /// <param name="c2">The c2.</param>
    /// <returns></returns>
    private static float Distance(Control c1, Control c2)
    {
      float y = Math.Abs(c1.Position.Y - c2.Position.Y);
      float x = Math.Abs(c1.Position.X - c2.Position.X);
      float distance = (float)Math.Sqrt(y * y + x * x);
      return distance;
    }

    /// <summary>
    /// returns the horizontal distance between 2 controls
    /// </summary>
    /// <param name="c1">The c1.</param>
    /// <param name="c2">The c2.</param>
    /// <returns></returns>
    private static float DistanceX(Control c1, Control c2)
    {
      float distance = Math.Abs(c1.Position.X - c2.Position.X);
      return distance;
    }

    /// <summary>
    /// returns the vertical distance between 2 controls
    /// </summary>
    /// <param name="c1">The c1.</param>
    /// <param name="c2">The c2.</param>
    /// <returns></returns>
    private static float DistanceY(Control c1, Control c2)
    {
      float distance = Math.Abs(c1.Position.Y - c2.Position.Y);
      return distance;
    }

    /// <summary>
    /// Predicts the next control which is position above this control
    /// </summary>
    /// <param name="focusedControl">The focused control.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    private static Control PredictFocusUp(Control focusedControl, ref Key key, bool strict)
    {
      Control bestMatch = null;
      Window window = focusedControl.Window;
      float bestDistance = float.MaxValue;
      foreach (Control c in window.Controls)
      {
        Control match = c.PredictFocusUp(focusedControl, ref key, strict);
        if (key == Key.None)
        {
          return match;
        }
        if (match != null)
        {
          if (match == focusedControl)
          {
            continue;
          }
          if (match.IsFocusable)
          {
            if (bestMatch == null)
            {
              bestMatch = match;
              bestDistance = Distance(match, focusedControl);
            }
            else
            {
              if (match.Position.Y + match.Height >= bestMatch.Position.Y + bestMatch.Height)
              {
                float distance = Distance(match, focusedControl);
                if (distance < bestDistance)
                {
                  bestMatch = match;
                  bestDistance = distance;
                }
              }
            }
          }
        }
      }
      if (bestMatch == null && strict && key != Key.None)
      {
        return PredictFocusUp(focusedControl, ref key, false);
      }
      return bestMatch;
    }

    /// <summary>
    /// Predicts the next control which is position below this control
    /// </summary>
    /// <param name="focusedControl">The focused control.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    private static Control PredictFocusDown(Control focusedControl, ref Key key, bool strict)
    {
      Control bestMatch = null;
      Window window = focusedControl.Window;
      float bestDistance = float.MaxValue;
      foreach (Control c in window.Controls)
      {
        Control match = c.PredictFocusDown(focusedControl, ref key, strict);
        if (key == Key.None)
        {
          return match;
        }
        if (match != null)
        {
          if (match == focusedControl)
          {
            continue;
          }
          if (match.IsFocusable)
          {
            if (bestMatch == null)
            {
              bestMatch = match;
              bestDistance = Distance(match, focusedControl);
            }
            else
            {
              if (match.Position.Y <= bestMatch.Position.Y)
              {
                float distance = Distance(match, focusedControl);
                if (distance < bestDistance)
                {
                  bestMatch = match;
                  bestDistance = distance;
                }
              }
            }
          }
        }
      }
      if (bestMatch == null && strict && key != Key.None)
      {
        return PredictFocusDown(focusedControl, ref key, false);
      }
      return bestMatch;
    }

    /// <summary>
    /// Predicts the next control which is positioned left of this control
    /// </summary>
    /// <param name="focusedControl">The focused control.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    private static Control PredictFocusLeft(Control focusedControl, ref Key key, bool strict)
    {
      Control bestMatch = null;
      Window window = focusedControl.Window;
      float bestDistance = float.MaxValue;
      foreach (Control c in window.Controls)
      {
        Control match = c.PredictFocusLeft(focusedControl, ref key, strict);
        if (key == Key.None)
        {
          return match;
        }
        if (match != null)
        {
          if (match == focusedControl)
          {
            continue;
          }
          if (match.IsFocusable)
          {
            if (bestMatch == null)
            {
              bestMatch = match;
              bestDistance = Distance(match, focusedControl);
            }
            else
            {
              if (match.Position.X >= bestMatch.Position.X)
              {
                float distance = Distance(match, focusedControl);
                if (distance < bestDistance)
                {
                  bestMatch = match;
                  bestDistance = distance;
                }
              }
            }
          }
        }
      }
      if (bestMatch == null && strict && key != Key.None)
      {
        return PredictFocusLeft(focusedControl, ref key, false);
      }
      return bestMatch;
    }

    /// <summary>
    /// Predicts the next control which is positioned right of this control
    /// </summary>
    /// <param name="focusedControl">The focused control.</param>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    private static Control PredictFocusRight(Control focusedControl, ref Key key, bool strict)
    {
      Control bestMatch = null;
      Window window = focusedControl.Window;
      float bestDistance = float.MaxValue;
      foreach (Control c in window.Controls)
      {
        Control match = c.PredictFocusRight(focusedControl, ref key, strict);
        if (key == Key.None)
        {
          return match;
        }
        if (match != null)
        {
          if (match == focusedControl)
          {
            continue;
          }
          if (match.IsFocusable)
          {
            if (bestMatch == null)
            {
              bestMatch = match;
              bestDistance = Distance(match, focusedControl);
            }
            else
            {
              if (match.Position.X <= bestMatch.Position.X)
              {
                float distance = Distance(match, focusedControl);
                if (distance < bestDistance)
                {
                  bestMatch = match;
                  bestDistance = distance;
                }
              }
            }
          }
        }
      }
      if (bestMatch == null && strict && key != Key.None)
      {
        return PredictFocusRight(focusedControl, ref key, false);
      }
      return bestMatch;
    }
#endif
    /// <summary>
    /// Gets or sets a value indicating whether skinengine needs raw key data (for a textbox for example)
    /// </summary>
    /// <value><c>true</c> if [need raw key data]; otherwise, <c>false</c>.</value>
    public bool NeedRawKeyData
    {
      get { return _needRawKeyboarData; }
      set { _needRawKeyboarData = value; }
    }
  }
}
