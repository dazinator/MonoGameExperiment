﻿using System;

namespace Monogame.Core.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RegisterAttribute : Attribute
    {
        public RegisterAttribute(RegistrationLifeTimes lifetime = RegistrationLifeTimes.InstancePerLifetimeScope)
        {
            LifeTime = lifetime;
        }

        public RegistrationLifeTimes LifeTime { get; set; }
        
    }
}