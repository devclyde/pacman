using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using pacman.Game.Stores;

namespace pacman.Game.Elements
{
    public sealed class GameRoom : CompositeDrawable
    {
        private readonly List<string[]> walls = new()
        {
            new string[] { "02", "07", "07", "07", "07", "07", "07", "07", "07", "07", "07", "07", "07", "14", },
            new string[] { "06", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "24", },
            new string[] { "06", "00", "32", "22", "22", "30", "00", "32", "22", "22", "22", "30", "00", "24", },
            new string[] { "06", "00", "23", "00", "00", "24", "00", "23", "00", "00", "00", "24", "00", "24", },
            new string[] { "06", "00", "31", "21", "21", "29", "00", "31", "21", "21", "21", "29", "00", "28", },
            new string[] { "06", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", },
            new string[] { "06", "00", "32", "22", "22", "30", "00", "32", "30", "00", "32", "22", "22", "22", },
            new string[] { "06", "00", "31", "21", "21", "29", "00", "23", "24", "00", "31", "21", "21", "25", },
            new string[] { "06", "00", "00", "00", "00", "00", "00", "23", "24", "00", "00", "00", "00", "23", },
            new string[] { "04", "08", "08", "08", "08", "25", "00", "23", "28", "22", "22", "30", "00", "23", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "26", "21", "21", "29", "00", "31", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "24", "00", "00", "00", "00", "00", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "24", "00", "34", "08", "08", "37", },
            new string[] { "07", "07", "07", "07", "07", "27", "00", "31", "29", "00", "05", "00", "00", "00", },
            new string[] { "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "05", "00", "00", "00", },
            new string[] { "08", "08", "08", "08", "08", "25", "00", "32", "30", "00", "05", "00", "00", "00", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "24", "00", "36", "07", "07", "07", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "24", "00", "00", "00", "00", "00", },
            new string[] { "00", "00", "00", "00", "00", "06", "00", "23", "24", "00", "32", "22", "22", "22", },
            new string[] { "02", "07", "07", "07", "07", "27", "00", "31", "29", "00", "31", "21", "21", "25", },
            new string[] { "06", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "23", },
            new string[] { "06", "00", "32", "22", "22", "25", "00", "00", "00", "00", "00", "00", "00", "23", },
            new string[] { "06", "00", "31", "21", "25", "24", "00", "00", "00", "00", "00", "00", "00", "31", },
            new string[] { "06", "00", "00", "00", "23", "24", "00", "00", "00", "00", "00", "00", "00", "00", },
            new string[] { "06", "00", "00", "00", "23", "24", "00", "00", "00", "00", "00", "00", "00", "00", },
            new string[] { "06", "00", "00", "00", "31", "29", "00", "00", "00", "00", "00", "00", "00", "00", },
            new string[] { "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", "00", },
        };

        private const string wallTexturePrefix = "Wall_";

        private FillFlowContainer<FillFlowContainer<Sprite>> roomFlows;

        private NearestTextureStore textures;

        [BackgroundDependencyLoader]
        private void Load(NearestTextureStore textures)
        {
            this.textures = textures;

            Size = new osuTK.Vector2(336);

            AddInternal(roomFlows = new FillFlowContainer<FillFlowContainer<Sprite>>
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Direction = FillDirection.Full,
                Size = new osuTK.Vector2(336)
            });

            DrawRoom();
        }

        private void DrawRoom()
        {
            foreach (var wall in walls)
            {
                var fill = new FillFlowContainer<Sprite>
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Direction = FillDirection.Horizontal,
                    Size = new osuTK.Vector2(168, 12)
                };

                var mirrorFill = new FillFlowContainer<Sprite>
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Direction = FillDirection.Horizontal,
                    Size = new osuTK.Vector2(168, 12),
                    Scale = new osuTK.Vector2(-1, 1)
                };

                foreach (var wallStr in wall)
                {
                    fill.Add(new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get($"{wallTexturePrefix}{wallStr}")
                    });
                    mirrorFill.Add(new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get($"{wallTexturePrefix}{wallStr}")
                    });
                }

                roomFlows.Add(fill);
                roomFlows.Add(mirrorFill);
            }
        }
    }
}
