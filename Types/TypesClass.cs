using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TypesClass
    {
        #region Déclaration des tableaux

        private string[] tTypes;
        private string[] tStyles;

        #endregion

        #region Enumeration

        public enum CodeTypes
        {
            Types,
            Styles
        }

        #endregion

        #region Constructeur

        public TypesClass()
        {
            InitTypes();
            InitStyles();
        }

        #endregion

        #region Initialisation

        private void InitTypes()
        {
            tTypes = new string[4] {"Chaise","Sofa","Table","Armoire"};
        }

        private void InitStyles()
        {
            tStyles = new string[6] {"Moderne","Gothique","Industriel","Rustique","Antiquité","International"};
        }

        #endregion

        public string[] GetTypes(CodeTypes type)
        {
            switch (type)
            {
                case CodeTypes.Types:
                    return tTypes;
                case CodeTypes.Styles:
                    return tStyles;
                default:
                    throw new ArgumentOutOfRangeException("Thomas Noel");
            }
        }

    }
}
