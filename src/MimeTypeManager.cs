﻿using DeaneBarker.Optimizely.StaticSites.Services;
using Microsoft.AspNetCore.StaticFiles;
using System.Linq;

namespace DeaneBarker.Optimizely.StaticSites
{
    public class MimeTypeManager : IMimeTypeManager
    {
        private readonly string[] additionalTextMime = new[] {
            "application/javascript",
            "application/x-javascript", // Weird, but it's out there
            "application/json",
            "application/ld+json",
            "application/xml",
            "application/xml-dtd"
        };

        public string GetMimeType(string path)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(path, out var contentType);
            return contentType ?? "text/plain";
        }

        public bool IsText(string mimeType)
        {
            mimeType = mimeType.Trim().ToLower();

            if(mimeType.StartsWith("text/"))
            {
                return true;
            }

            if(mimeType.EndsWith("+xml"))
            {
                return true; // Lots of weird one-offs like "application/whatever+xml"
            }

            return additionalTextMime.Contains(mimeType);
        }
    }
}
