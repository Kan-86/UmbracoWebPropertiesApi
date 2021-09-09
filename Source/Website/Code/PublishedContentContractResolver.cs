using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using Newtonsoft.Json.Utilities;

namespace Website.Code
{
    public class PublishedContentContractResolver : DefaultContractResolver
    {
        public new static readonly PublishedContentContractResolver Instance = new PublishedContentContractResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = instance =>
            {

                if (property.PropertyName == "CompositionAliases") return false;
                if (property.PropertyName == "ContentSet") return false;
                if (property.PropertyName == "PropertyTypes") return false;
                if (property.PropertyName == "ObjectContent") return false;
                if (property.PropertyName == "Properties") return false;
                if (property.PropertyName == "Parent") return false;
                if (property.PropertyName == "Children") return false;
                if (property.PropertyName == "ChildrenForAllCultures") return false;
                if (property.PropertyName == "DocumentTypeId") return false;
                if (property.PropertyName == "WriterName") return false;
                if (property.PropertyName == "CreatorName") return false;
                if (property.PropertyName == "WriterId") return false;
                if (property.PropertyName == "CreatorId") return false;
                if (property.PropertyName == "CreateDate") return false;
                if (property.PropertyName == "UpdateDate") return false;
                if (property.PropertyName == "Version") return false;
                if (property.PropertyName == "SortOrder") return false;
                if (property.PropertyName == "TemplateId") return false;
                if (property.PropertyName == "IsDraft") return false;
                if (property.PropertyName == "ItemType") return false;
                if (property.PropertyName == "ContentType") return false;
                if (property.PropertyName == "Url") return false;
                if (property.PropertyName == "ContentSet") return false;

                return true;
            };

            return property;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            return contract;
        }
    }
}