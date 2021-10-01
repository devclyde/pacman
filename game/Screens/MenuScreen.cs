using System.Linq;
using osu.Framework.Screens;
using osu.Framework.Graphics;
using pacman.Game.Graphics;
using pacman.Game.Graphics.UserInterface;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Bindings;
using pacman.Game.Input;
using osu.Framework.Bindables;

namespace pacman.Game.Screens
{
    public class MenuScreen : Screen
    {
        public MenuScreen()
        {
            AddRangeInternal(new Drawable[]
            {
                new ButtonKeyBindingContainer
                {
                    new ButtonFillFlowContainer
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Spacing = new osuTK.Vector2(40),
                        Direction = FillDirection.Vertical,
                        Children = new ArcadeButton[]
                        {
                            new(() => this.Push(new GameScreen()))
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Title = "START GAME"
                            },
                            new(() => this.Push(new OptionsScreen()))
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Title = "OPTIONS"
                            },
                            new(() => this.Push(new AboutScreen()))
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Title = "ABOUT"
                            },
                        }
                    },
                },
                new PacmanLogo
                {
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                    RelativePositionAxes = Axes.Both,
                    Y = 0.1f
                },
                new ArcadeSpriteText
                {
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.Centre,
                    RelativePositionAxes = Axes.Both,
                    Y = -0.05f,
                    FontSize = 16,
                    Colour = Colour4.White,
                    Text = "TM & COPYRIGHT 1980-2021 NAMCO LTD. ALL RIGHTS RESERVED"
                }
            });
        }
    }

    public class ButtonFillFlowContainer : FillFlowContainer<ArcadeButton>, IKeyBindingHandler<ButtonInputAction>
    {
        private readonly Bindable<int> currentSelected;

        public ButtonFillFlowContainer()
        {
            currentSelected = new();
            currentSelected.BindValueChanged(SelectedChanged);
        }

        protected override void LoadComplete()
        {
            currentSelected.Value = 0;
            Children[0].Selected = true;

            base.LoadComplete();
        }

        private void SelectedChanged(ValueChangedEvent<int> e)
        {
            Children[e.OldValue].Selected = false;
            Children[e.NewValue].Selected = true;
        }

        public bool OnPressed(ButtonInputAction action)
        {
            switch (action)
            {
                case ButtonInputAction.Next:
                    if (currentSelected.Value == Children.ToArray().Length - 1)
                        currentSelected.Value = 0;
                    else
                        currentSelected.Value++;
                    return true;
                case ButtonInputAction.Previous:
                    if (currentSelected.Value == 0)
                        currentSelected.Value = Children.ToArray().Length - 1;
                    else
                        currentSelected.Value--;
                    return true;
                case ButtonInputAction.Press:
                    Children[currentSelected.Value].Execute();
                    return true;
            }

            return true;
        }

        public void OnReleased(ButtonInputAction action)
        {
            return;
        }
    }
}
