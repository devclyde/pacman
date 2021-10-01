using System;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace pacman.Game.Graphics.UserInterface
{
    public class ArcadeButton : CompositeDrawable
    {
        public string Title { get; init; }
        public bool Selected
        {
            get => selectedBindable.Value;
            set
            {
                selectedBindable.Value = value;
            }
        }

        private readonly Bindable<bool> selectedBindable;
        private readonly ArcadeSpriteText text;

        private readonly Action execute;

        public ArcadeButton(Action action)
        {
            selectedBindable = new(false);
            selectedBindable.BindValueChanged(OnChange);

            AddRangeInternal(new[]
            {
                text = new()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Colour = Colour4.White
                }
            });

            execute = action;
        }

        protected override void LoadComplete()
        {
            text.Text = Title;

            base.LoadComplete();
        }

        private void OnChange(ValueChangedEvent<bool> e)
        {
            switch (e.NewValue)
            {
                case true:
                    text.Colour = Colour4.FromHex("#ffcc22");
                    break;
                case false:
                    text.Colour = Colour4.White;
                    break;
            }

            return;
        }

        public void Execute()
        {
            execute?.Invoke();
        }
    }
}
