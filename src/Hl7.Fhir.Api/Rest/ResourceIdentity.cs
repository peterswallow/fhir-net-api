﻿using Hl7.Fhir.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hl7.Fhir.Rest
{
    public class ResourceIdentity : Uri
    {
        public ResourceIdentity(string uri) : base(uri, UriKind.RelativeOrAbsolute) {  }
        public ResourceIdentity(Uri uri) : base(uri.ToString(), UriKind.RelativeOrAbsolute) { }
        internal ResourceIdentity(string uri, UriKind kind) : base(uri, kind) { }
        

        /// <summary>
        /// Creates an absolute Uri representing a Resource identitity for a given resource type, id and optional version.
        /// </summary>
        /// <param name="endpoint">Absolute path giving the FHIR service endpoint</param>
        /// <param name="collection">Name of the collection (resource type)</param>
        /// <param name="id">The resource's logical id</param>
        /// <param name="vid">The resource's version id</param>
        /// <returns></returns>
        public static ResourceIdentity Build(Uri endpoint, string collection, string id, string vid=null)
        {
            if (collection == null) Error.ArgumentNull("collection");
            if (id == null) Error.ArgumentNull("id");
            if (!endpoint.IsAbsoluteUri) Error.Argument("endpoint", "endpoint must be an absolute path");
            
            if(vid != null)
                return new ResourceIdentity(construct(endpoint, collection, id, RestOperation.HISTORY, vid));
            else
                return new ResourceIdentity(construct(endpoint, collection, id));
        }


        /// <summary>
        /// Creates a relative Uri representing a Resource identitity for a given resource type, id and optional version.
        /// </summary>
        /// <param name="collection">Name of the collection (resource type)</param>
        /// <param name="id">The resource's logical id</param>
        /// <param name="vid">The resource's version id</param>
        /// <returns></returns>

        public static ResourceIdentity Build(string collection, string id, string vid=null)
        {
            if (collection == null) Error.ArgumentNull("collection");
            if (id == null) Error.ArgumentNull("id");
            if (vid == null) Error.ArgumentNull("vid");

            string url = vid != null ?
                string.Format("{0}/{1}/{2}/{3}", collection, id, RestOperation.HISTORY, vid) :
                string.Format("{0}/{1}", collection, id);
            
            return new ResourceIdentity(url, UriKind.Relative);
        }
        
        
        // Encure path ends in a '/'
        private static string delimit(string path)
        {
            return path.EndsWith(@"/") ? path : path + @"/";
        }


        private static Uri construct(Uri endpoint, IEnumerable<string> components)
        {
            UriBuilder builder = new UriBuilder(endpoint);
            string _path = delimit(builder.Path);
            string _components = string.Join("/", components).Trim('/');
            builder.Path = _path + _components;

            return builder.Uri;
        }

        private static Uri construct(Uri endpoint, params string[] components)
        {
            return construct(endpoint,(IEnumerable<string>)components);
        }

        private List<string> _components = null;

        private IEnumerable<string> splitPath()
        {
            string path = (this.IsAbsoluteUri) ? this.LocalPath : this.ToString();
            return path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        }

        internal List<string> Components
        {
            get
            {
                if (_components == null)
                {
                    _components = splitPath().ToList();
                }
                return _components;
            }
        }

       
        /// <summary>
        /// This is the FHIR service endpoint where the resource is located.
        /// </summary>
        public Uri Endpoint
        {
            get
            {
                int count = Components.Count;
                int index = Components.IndexOf(RestOperation.HISTORY);
                int n = (index > 0) ? 4 : 2;
                IEnumerable<string> _components = Components.Skip(count - n);
                string path = string.Join("/", _components).Trim('/');
                string s = this.ToString();
                string endpoint = s.Remove(s.LastIndexOf(path));
                
                return (endpoint.Length > 0) ? new Uri(endpoint) : null;
                
            }
        }

        /// <summary>
        /// The name of the resource as it occurs in the Resource url
        /// </summary>
        public string Collection
        {
            get 
            {
                int index = Components.IndexOf(RestOperation.HISTORY);
                if (index >= 2)
                {
                    return Components[index - 2];
                }
                else if (Components.Count >= 2)
                {
                    return Components[Components.Count - 2];
                }
                else
                {
                    return null;
                }                 
            }            
        }


        /// <summary>
        /// The logical id of the resource as it occurs in the Resource url
        /// </summary>
        public string Id
        {
            get
            {
                int index = Components.IndexOf(RestOperation.HISTORY);

                if (index >= 2)
                {
                    return Components[index - 1];
                }
                else if (index == -1 && Components.Count >= 2)
                {
                    return Components[Components.Count - 1];
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// The version id of the resource as it occurs in the Resource url
        /// </summary>
        public string VersionId
        {
            get
            {
                int index = Components.IndexOf(RestOperation.HISTORY);
                if (index >= 2 && Components.Count >= 4)
                {
                    return Components[index + 1];
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Indicates whether this ResourceIdentity is version-specific (has a _history part)
        /// </summary>
        public bool HasVersion
        {
            get
            {
                return VersionId != null;
            }
        }

        /// <summary>
        /// Returns a new ResourceIdentity made specific for the given version
        /// </summary>
        /// <param name="version">The version to add to the ResourceIdentity (part after the _history/)</param>
        /// <returns></returns>
        public ResourceIdentity WithVersion(string version)
        {
            Uri endpoint = this.Endpoint;

            if (endpoint == null)
                return ResourceIdentity.Build(this.Collection, this.Id, version);
            else
                return ResourceIdentity.Build(this.Endpoint, this.Collection, this.Id, version); 
            /*
            int index = Components.IndexOf(RestOperation.HISTORY);

            if (index == -1)
                return new ResourceIdentity(construct(this, RestOperation.HISTORY, version));
            else
            {
                
                var path = construct(new Uri(getHost()), Components.Take(index).Concat( new string[] { RestOperation.HISTORY, version }));
                return new ResourceIdentity(path);
            }
            */
        }

        /// <summary>
        /// Turns a version-specific ResourceIdentity into a non-version-specific ResourceIdentity
        /// </summary>
        /// <returns></returns>
        public ResourceIdentity WithoutVersion()
        {
            Uri endpoint = this.Endpoint;

            if (endpoint == null)
                return ResourceIdentity.Build(this.Collection, this.Id);
            else
                return ResourceIdentity.Build(endpoint, this.Collection, this.Id); 
            /*
            int index = Components.IndexOf(RestOperation.HISTORY);

            if (index == -1)
                return this;
            else
            {
                var path = construct(new Uri(getHost()), Components.Take(index));
                return new ResourceIdentity(path);
            }
            */
        }


        /// <summary>
        /// Returns a Uri that is a relative version of the ResourceIdentity
        /// </summary>
        public Uri OperationPath
        {
            get
            {
                // dit maakt de uri altijd relatief
                return ResourceIdentity.Build(this.Collection, this.Id, this.VersionId);
            }
        }
    }

   
}
