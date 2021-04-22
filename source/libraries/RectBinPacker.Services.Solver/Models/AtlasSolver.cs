using RectBinPacker.Interfaces;
using RectBinPacker.Services.Solver.Interfaces;
using RectBinPacker.Services.Solver.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RectBinPacker.Services.Solver.Models
{
    internal class AtlasSolver<T> : IAtlasSolver<T> where T :IItem
    {
        public int Width { set; internal get; }
        public int Height { set; internal get; }
        public IList<T> Items { set; internal get; }
        public IList<IValidator> Validators { set; internal get; }

        public bool IsConfigured()
        {
            // make sure our item list isn't null
            if (Items == null)
                return false;

            // make sure none of our items are null
            if (Items.Any(it => it == null))
                return false;

            // create an empty validator list
            if (Validators == null)
                Validators = new List<IValidator>();

            // make sure our validator list doesn't contain null values
            if (Validators.Any(va => va == null))
                return false;

            // return true if the above checks pass
            return true;
        }

        public IAtlas<T> Solve()
        {
            if (!IsConfigured())
                throw new InvalidOperationException("AtlasSolver is not properly configured");
            
            // create our atlas
            var atlas = new Atlas<T>
            {
                Height = Height,
                Width = Width,
                ConfiguredItems = Items.Select(it => new ConfiguredItem<T>
                {
                    Scale = 1,
                    OriginalItem = it
                }).ToList()
            };

            // ensure that we currently pass validation
            Validate(atlas, Validators);

            // determine our initial scale
            decimal scale = (decimal)atlas.Area() / atlas.ConfiguredItems.Sum(ci => ci.Area());
            if (scale > 1)
            {
                scale = 1;
            }

            // set our initial scale
            foreach (var ci in atlas.ConfiguredItems)
                ci.Scale = scale;

            // ensure that we currently pass validation
            Validate(atlas, Validators);

            // sort from largest to smallest
            atlas.ConfiguredItems = atlas.ConfiguredItems.OrderByDescending(ci => ci.Area()).ToList();
            
            // iterate until the atlas is solved
            while (atlas.ConfiguredItems.Any(ci => ci.Placed == false))
            {
                // iterate our step count
                atlas.StepCount += 1;

                // ensure that we currently pass validation
                Validate(atlas, Validators);

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

            // ensure that we pass validation one last time
            Validate(atlas, Validators);

            // return
            return atlas;
        }

        private bool Validate(IAtlas<T> atlas, IList<IValidator> validators) 
        {
            foreach (var v in validators)
            {
                string errorMessage;
                string parameterName;

                if (!v.Validate(atlas, out parameterName, out errorMessage))
                {
                    throw new ArgumentOutOfRangeException(parameterName, errorMessage);
                }
            }

            return true;
        }
    }
}
