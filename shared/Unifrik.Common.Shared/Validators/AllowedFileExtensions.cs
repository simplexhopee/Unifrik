using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Unifrik.Common.Shared.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly HashSet<string> _extensions;
        private readonly long _maxFileSizeInBytes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extensions">Allowed extensions e.g. ".jpg", ".png"</param>
        /// <param name="maxFileSizeInBytes">Maximum file size in bytes</param>
        public AllowedExtensionsAttribute(string[] extensions, long maxFileSizeInBytes)
        {
            if (extensions == null || extensions.Length == 0)
                throw new ArgumentException("Extensions cannot be null or empty");

            _extensions = new HashSet<string>(
                extensions.Select(e => e.StartsWith(".") ? e.ToLowerInvariant() : "." + e.ToLowerInvariant())
            );

            if (maxFileSizeInBytes <= 0)
                throw new ArgumentException("Max file size must be greater than zero");

            _maxFileSizeInBytes = maxFileSizeInBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is not IFormFile file)
                return new ValidationResult("Invalid file type");

            // Check extension
            var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !_extensions.Contains(extension))
            {
                return new ValidationResult(
                    $"Invalid file extension. Allowed extensions: {string.Join(", ", _extensions)}"
                );
            }

            // Check file size
            if (file.Length > _maxFileSizeInBytes)
            {
                var maxSizeInMb = _maxFileSizeInBytes / (1024.0 * 1024.0);
                return new ValidationResult(
                    $"File size exceeds the maximum allowed size of {maxSizeInMb:0.##} MB"
                );
            }

            return ValidationResult.Success;
        }
    }
}
