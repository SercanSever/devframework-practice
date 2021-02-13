using DevFramework.Core.CrossCuttıngConcerns.Logging;
using DevFramework.Core.CrossCuttıngConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)] //nesne örneklerinin metotlarına uygula. constructor a uygulama.
    public class LogAspect : OnMethodBoundaryAspect
    {
        Type _loggerType;
        LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wronk Logger Type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }
            try
            {
                var logParameteres = args.Method.GetParameters().Select((t, i) => new LogParameter  //t = tip   i = argüman iterator.
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();
                base.OnEntry(args);

                var logDetail = new LogDetail
                {
                    NameSpace = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameteres
                };
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {
            }

        }
    }
}
