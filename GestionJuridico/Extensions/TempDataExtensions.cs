using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GestionJuridico.Extensions;

public static class AlertMessageTypes
{
    public const string Success = "success";
    public const string Warning = "warning";
    public const string Info = "info";
    public const string Danger = "danger";
}

public static class TempDataExtensions
{
    public static void MessageSuccess(this ITempDataDictionary tempData, string message)
    {
        var typeMessage = AlertMessageTypes.Success;
        tempData["alertMessage"] = message;
        tempData["typeMessage"] = typeMessage;
    }

    public static void MessageWarning(this ITempDataDictionary tempData, string message)
    {
        var typeMessage = AlertMessageTypes.Warning;
        tempData["alertMessage"] = message;
        tempData["typeMessage"] = typeMessage;
    }

    public static void MessageInfo(this ITempDataDictionary tempData, string message)
    {
        var typeMessage = AlertMessageTypes.Info;
        tempData["alertMessage"] = message;
        tempData["typeMessage"] = typeMessage;
    }

    public static void MessageDanger(this ITempDataDictionary tempData, string message)
    {
        var typeMessage = AlertMessageTypes.Danger;
        tempData["alertMessage"] = message;
        tempData["typeMessage"] = typeMessage;
    }
}