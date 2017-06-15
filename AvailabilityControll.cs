using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices; 

namespace RevitRedevelop
{
    class AvailabilityControll : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData,
                                     Autodesk.Revit.DB.CategorySet selectedCategories)
        {
          
            return false;
        }
    }
}
