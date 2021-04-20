using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RectBinPacker.Services.Solver.Models
{
    internal class Solver : ISolver
    {
        private IList<IItem> _items;
        private IList<ISolverValidator> _validators = new List<ISolverValidator>();

        public void Configure(IList<IItem> items, IList<ISolverValidator> validators = null)
        {
            _items = items;

            if (validators != null)
                _validators = validators;
        }

        public bool IsConfigured()
        {
            // make sure our item list isn't null
            if (_items == null)
                return false;

            // make sure our item list isn't empty
            if (_items.Count == 0)
                return false;

            // make sure our item list doesn't have any null values
            if (_items.Any(it => it == null))
                return false;

            // make sure our validator list doesn't contain null values
            if (_validators.Any(it => it == null))
                return false;

            // return true if the above checks pass
            return true;
        }

        public IAtlas Solve()
        {
            if (!IsConfigured())
                throw new InvalidOperationException("Solver.Solve is not properly configured");

            int width = 256;
            int height = 256;
            
            // create our atlas
            var atlas = new Atlas
            {
                Height = height,
                Width = width,
                ConfiguredItems = _items.Select(it => new ConfiguredItem
                {
                    Scale = 1,
                    OriginalItem = it
                }).ToList()
            };

            decimal scale = (decimal)atlas.Area() / atlas.ConfiguredItems.Sum(ci => ci.Area());
            if (scale > 1)
            {
                scale = 1;
            }

            foreach (var ci in atlas.ConfiguredItems)
                ci.Scale = scale;

            atlas.ConfiguredItems = atlas.ConfiguredItems.OrderByDescending(ci => ci.Area()).ToList();
            while (atlas.ConfiguredItems.Any(ci => ci.Placed == false))
            {
                // if the sum of the configured item area is bigger than
                // the sum of the atlas area, start shrinking down items
                /*if ()
                {
                    atlas.ConfiguredItems = atlas.ConfiguredItems.OrderByDescending(ci => ci.Area()).ToList();
                    atlas.ConfiguredItems.Where(ci => ci.Placed == false).FirstOrDefault().Scale += -.05f;
                    continue;
                }*/

                // go through canvas, vertically then horizontally
                for (int iY = 0; iY < atlas.Height - 1; iY++)
                {
                    for (int iX = 0; iX < atlas.Width - 1; iX++)
                    {
                        //use placeholders
                        int x = iX;
                        int y = iY;

                        //get the first image placed in this location
                        var firstPlaced = atlas.ConfiguredItems.FirstOrDefault(ci => ci.OccupiesSpace(x, y));

                        //get the first image not placed
                        var firstAvailable = atlas.ConfiguredItems.FirstOrDefault(ci => (ci.Placed == false) &&
                                                                    (x + ci.Width - 1 <= atlas.Width) &&
                                                                    (y + ci.Height - 1 <= atlas.Height));

                        //we can  only place if there's no image placed at the location AND
                        //if there's a new image that can fit
                        if ((firstPlaced == null) && (firstAvailable != null))
                        {
                            firstAvailable.Placed = true;
                            firstAvailable.X = x;
                            firstAvailable.Y = y;

                            //move the cursor over by the width of the image
                            iX = iX + firstAvailable.Width - 1;
                        }
                        else if (firstPlaced != null)
                        {
                            //move the cursor over by the width of the image
                            iX = iX + firstPlaced.Width - 1;
                        }

                        //escape the loop if there's nothing left to place
                        if (atlas.ConfiguredItems.All(i => i.Placed == true))
                            break;
                    }

                    //escape the loop if there's nothing left to place
                    if (atlas.ConfiguredItems.All(i => i.Placed == true))
                        break;
                }
            }

            return atlas;
        }
    }
}
