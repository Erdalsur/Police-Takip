﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Policem.Core.Core.Aspects.ExceptionAspects
{
    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        //[NonSerialized] private LoggerService _loggerService;
        private readonly Type _loggerType;

        public ExceptionAspect(Type loggerType = null)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            //if (_loggerType != null)
            //{
            //    if (_loggerType.BaseType != typeof(LoggerService))
            //        throw new Exception("Wrong Logger Type");

            //    _loggerService = (LoggerService)Activator.CreateInstance(_loggerType, Type.EmptyTypes);
            //}

            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            //if (_loggerService != null)
            //{
            //    _loggerService.Error(args.Exception);
            //}
        }
    }
}