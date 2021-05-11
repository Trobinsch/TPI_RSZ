using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Exceptions
{
    public class ApplicationSettingsError : Exception
    {
        public ApplicationSettingsError()
            : base("Un problème de configuration est survenu. veuillez contacter le support.")
        { }
    }
}
