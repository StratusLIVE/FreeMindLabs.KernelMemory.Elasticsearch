// Copyright (c) Free Mind Labs, Inc. All rights reserved.

using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace FreeMindLabs.KernelMemory.Elasticsearch;

/// <summary>
/// Elasticsearch configuration extensions.
/// </summary>
public static class ElasticsearchConfigExtensions
{
    /// <summary>
    /// Converts an ElasticsearchConfig to a ElasticsearchClientSettings that can be used
    /// to instantiate <see cref="ElasticsearchClient"/>.
    /// </summary>
    public static ElasticsearchClientSettings ToElasticsearchClientSettings(this ElasticsearchConfig config)
    {
        ArgumentNullException.ThrowIfNull(config, nameof(config));

        // TODO: figure out the Dispose issue. It does not feel right.
        // See https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/_options_on_elasticsearchclientsettings.html
#pragma warning disable CA2000 // Dispose objects before losing scope
        var settings = new ElasticsearchClientSettings(new Uri(config.Endpoint))
            .DisableDirectStreaming(true)
            .ThrowExceptions(true);

        // Prioritize ApiKey if available; otherwise, fall back to BasicAuthentication
        if (!string.IsNullOrEmpty(config.ApiKey))
        {
            settings.Authentication(new ApiKey(config.ApiKey));
        }
        else if (!string.IsNullOrEmpty(config.UserName) && !string.IsNullOrEmpty(config.Password))
        {
            settings.Authentication(new BasicAuthentication(config.UserName, config.Password));
        }
        else
        {
            // Handle the scenario where neither ApiKey nor credentials are provided
            throw new Exception("Either ApiKey or UserName and Password must be provided in the configuration.");
        }

        // Uncomment the following lines if you determined the certificate validation settings are necessary
        // after verification
        // .ServerCertificateValidationCallback((sender, certificate, chain, errors) => true)
        // .CertificateFingerprint(config.CertificateFingerPrint)

        return settings;
    }
}
