﻿using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    // TODO: Use internal/private constructors for all response types?
    public abstract class ErgastResponse
    {
        [JsonProperty("url")]
        public virtual string RequestUrl { get; private set; }

        [JsonProperty("limit")]
        public virtual int Limit { get; private set; }

        [JsonProperty("offset")]
        public virtual int Offset { get; private set; }

        [JsonProperty("total")]
        public virtual int TotalResults { get; private set; }

        // TODO: Note that it can be inaccurate if limit/offset do not correlate
        // TODO: Test with 0 values
        public virtual int Page => Offset / Limit + 1;

        // TODO: Test with 0 values
        public virtual int TotalPages => (int) Math.Ceiling(TotalResults / (double)Limit);

        // TODO: Test
        public virtual bool HasMorePages => TotalResults > Limit + Offset;
    }
}