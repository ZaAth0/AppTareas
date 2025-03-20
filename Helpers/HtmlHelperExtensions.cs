using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

public static class HtmlHelperExtensions
 {
     public static IHtmlContent ActionLinkWithIcon(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string iconClass, object routeValues = null, object htmlAttributes = null)
     {
         // Obtener el LinkGenerator del contenedor de servicios
         var linkGenerator = htmlHelper.ViewContext.HttpContext.RequestServices.GetRequiredService<LinkGenerator>();

         // Generar la URL utilizando el LinkGenerator
         var url = linkGenerator.GetPathByAction(actionName, controllerName, routeValues);

         // Crear el elemento <i> para el icono
         var iconTag = new TagBuilder("i");
         iconTag.AddCssClass(iconClass);

         // Crear el elemento <a> para el enlace
         var anchorTag = new TagBuilder("a");
         anchorTag.Attributes["href"] = url;
         anchorTag.InnerHtml.AppendHtml(iconTag);
         anchorTag.InnerHtml.Append($" {linkText}");

         // Añadir atributos HTML adicionales si existen
         if (htmlAttributes != null)
         {
             var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
             anchorTag.MergeAttributes(attributes);
         }

         return anchorTag;
     }
 }