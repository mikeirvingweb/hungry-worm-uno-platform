﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace HungryWormGame
{
    public class PlayerTrail : GameObject
    {
        #region Fields

        private double _radius;

        #endregion

        #region Ctor

        public PlayerTrail(double scale)
        {
            Tag = ElementType.PLAYER_TRAIL;

            SetRoundness(scale);

            Background = Application.Current.Resources["WormBodyColor"] as SolidColorBrush;
            BorderBrush = Application.Current.Resources["WormBorderColor"] as SolidColorBrush;

            Width = Constants.PLAYER_TRAIL_SIZE * scale;
            Height = Constants.PLAYER_TRAIL_SIZE * scale;
        }

        #endregion

        #region Methods

        public void SetRoundness(double scale)
        {
            _radius = 10 * scale;
            CornerRadius = new CornerRadius(_radius);
        }

        #endregion
    }
}
