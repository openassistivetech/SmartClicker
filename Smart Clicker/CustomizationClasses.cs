﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smart_Clicker
{
    public class CustomizationParameters
    {
        public ClickCustomization clickValues;
        public LayoutCustomization layoutValues;
        public ContextCustomization contextValues;


        public CustomizationParameters()
        {

            this.clickValues = new ClickCustomization();
            this.layoutValues = new LayoutCustomization();
            this.contextValues = new ContextCustomization();

        }

        public static CustomizationParameters createDefault()
        {
            CustomizationParameters defaultParameters = new CustomizationParameters();
            defaultParameters.clickValues = new ClickCustomization();
            defaultParameters.clickValues.timeout = 1;
            defaultParameters.clickValues.clickBoundingBox = 25;
            defaultParameters.layoutValues = new LayoutCustomization();
            defaultParameters.layoutValues.hiddenIconNames = new List<string>();
            defaultParameters.layoutValues.restartOnCrash = true;
            defaultParameters.layoutValues.startOnStartup = false;
            defaultParameters.contextValues = new ContextCustomization();
            defaultParameters.contextValues.clickAndDragBitmaps = new List<Bitmap>();
            defaultParameters.contextValues.doubleClickBitmaps = new List<Bitmap>();
            defaultParameters.contextValues.rightClickBitmaps = new List<Bitmap>();
            return defaultParameters;
        }

        public CustomizationParameters copy()
        {
            CustomizationParameters copy = new CustomizationParameters();
            copy.clickValues = this.clickValues.copy();
            copy.layoutValues = this.layoutValues.copy();
            copy.contextValues = this.contextValues.copy();
            return copy;

        }

        public void merge(CustomizationParameters newCustomization)
        {
            this.clickValues = newCustomization.clickValues;
            this.layoutValues = newCustomization.layoutValues;
            this.contextValues = newCustomization.contextValues;
        }
    }

    public class ClickCustomization
    {
        // In ms
        public double timeout;
        // In pixels
        public int clickBoundingBox;

        public ClickCustomization copy()
        {
            ClickCustomization copy = new ClickCustomization();
            copy.timeout = this.timeout;
            copy.clickBoundingBox = this.clickBoundingBox;
            return copy;
        }
    }

    public class LayoutCustomization
    {
        public List<string> hiddenIconNames;
        public int startWidth;
        public int startHeight;
        public int totalModes;
        public bool restartOnCrash;
        public bool startOnStartup;

        public LayoutCustomization copy()
        {
            LayoutCustomization copy = new LayoutCustomization();
            string[] copyList = new string[this.hiddenIconNames.Count];
            this.hiddenIconNames.CopyTo(copyList);
            copy.hiddenIconNames = copyList.ToList<string>();
            copy.startWidth = this.startWidth;
            copy.startHeight = this.startHeight;
            copy.totalModes = this.totalModes;
            copy.restartOnCrash = this.restartOnCrash;
            copy.startOnStartup = this.startOnStartup;
            return copy;
        }
    }

    public class ContextCustomization
    {
        public List<Bitmap> clickAndDragBitmaps;
        public List<Bitmap> doubleClickBitmaps;
        public List<Bitmap> rightClickBitmaps;

        // replace with actual copy method once we implement context customization
        public ContextCustomization copy()
        {
            return this;
        }
    }


}
