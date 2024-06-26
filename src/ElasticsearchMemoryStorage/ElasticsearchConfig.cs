﻿// Copyright (c) Free Mind Labs, Inc. All rights reserved.

using Elastic.Clients.Elasticsearch.Mapping;

namespace FreeMindLabs.KernelMemory.Elasticsearch;

/// <summary>
/// The configuration for the Elasticsearch connector.
/// Use <see cref="ElasticsearchConfigBuilder"/> to instantiate and configure this class.
/// </summary>
public class ElasticsearchConfig
{
    /// <inheritdoc />
    public ElasticsearchConfig()
    { }

    /// <summary>
    /// The certificate fingerprint for the Elasticsearch instance.
    /// See <see href="https://www.elastic.co/guide/en/elasticsearch/reference/current/configuring-stack-security.html#_use_the_ca_fingerprint_5"/>.
    /// </summary>
    public string CertificateFingerPrint { get; set; } = string.Empty;

    /// <summary>
    /// The Elasticsearch endpoint.
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>
    /// The username used to connect to Elasticsearch.
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The password used to connect to Elasticsearch.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The ApiKey used to connect to Elasticsearch.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// The prefix to be prepend to the index names in Elasticsearch.
    /// </summary>
    public string IndexPrefix { get; set; } = string.Empty;

    /// <summary>
    /// The number of shards to use for the Elasticsearch index.
    /// </summary>
    public int? ShardCount { get; set; } = 1;

    /// <summary>
    /// The number of replicas to use for the Elasticsearch index.
    /// </summary>
    public int? ReplicaCount { get; set; } = 0;

    /// <summary>
    /// A delegate to configure the Elasticsearch index properties.
    /// </summary>
    public Action<PropertiesDescriptor<ElasticsearchMemoryRecord>>? ConfigureProperties { get; internal set; }
}
