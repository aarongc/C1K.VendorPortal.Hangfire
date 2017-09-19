using System;
using System.Reflection;

namespace C1K.VendorPortal.BackgroundServices.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}