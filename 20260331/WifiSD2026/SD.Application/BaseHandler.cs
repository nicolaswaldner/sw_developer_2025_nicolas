using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SD.Application
{
    public class BaseHandler
    {
        //Methode, um die Eigenschaften von einem DTO auf eine Entity zu übertragen.
        //excludeProperties ermöglicht es, bestimmte Eigenschaften auszuschließen, die nicht übertragen werden sollen
        protected void MapEntityProperties<TSource, TTarget>(TSource source, TTarget target, List<string> excludeProperties = null) //Source ist DTO, Target ist Entity
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();

            if(sourceType.BaseType.FullName != targetType.BaseType.FullName)
            {
                throw new InvalidOperationException("Die Typen von Source und Target müssen übereinstimmen.");
            }

            //GetProperties gibt alle Eigenschaften zurück, die den angegebenen BindingFlags entsprechen. In diesem Fall werden nur öffentliche
            var targetPropertyInfos = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();

            targetPropertyInfos.ForEach(p =>
            {
                if (p.CanWrite && !(excludeProperties ?? []).Contains(p.Name)) 
                {
                    //passende property aus quelle (source) holen, GetProperty nur einzelne Eigenschaft, GetProperties alle Eigenschaften
                    var sourcePropertyInfo = sourceType.GetProperty(p.Name, BindingFlags.Public | BindingFlags.Instance);

                    if(sourcePropertyInfo != null)
                    {
                        //property wert aus quelle lesen
                        var sourcePropertyValue = sourcePropertyInfo.GetValue(source, null);

                        //ausgelesener wert in ziel (target) schreiben
                        p.SetValue(target, sourcePropertyValue, null);
                    }
                }
            });
        }
    }
}
