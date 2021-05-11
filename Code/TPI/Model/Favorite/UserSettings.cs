using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserSettings
    {
        #region attributs
        private int posX;
        private int posY;
        private int sizeX;
        private int sizeY;
        #endregion attributs

        #region constructors
        public UserSettings()
        { }

        public UserSettings(int posX, int posY, int sizeX, int sizeY)
        {
            this.posX = posX;
            this.posY = posY;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
        #endregion constructors

        #region accessors and mutators
        public int PosX
        {
            get { return this.posX; }
            set { this.posX = value; }
        }
        public int PosY
        {
            get { return this.posY; }
            set { this.posY = value; }
        }
        public int SizeX
        {
            get { return this.sizeX; }
            set { this.sizeX = value; }
        }
        public int SizeY
        {
            get { return this.sizeY; }
            set { this.sizeY = value; }
        }
        #endregion accessors and mutators
    }
}
