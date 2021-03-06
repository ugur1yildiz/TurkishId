﻿// <copyright file="TurkishIdAttribute.cs" company="Sedat Kapanoglu">
//      Copyright 2014 Sedat Kapanoglu
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;

namespace TurkishId
{
    /// <summary>
    /// Validation attribute for Turkish ID numbers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class TurkishIdAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // It's impossible to call this method with a null value
            // because ValidationContext throws ArgumentNullException on null instance values.
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return TurkishIdNumber.IsValid(value.ToString()) ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }
    }
}