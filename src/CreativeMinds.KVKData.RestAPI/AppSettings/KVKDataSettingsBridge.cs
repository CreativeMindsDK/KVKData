using Microsoft.Extensions.Options;
using System;

namespace CreativeMinds.KVKData.RestAPI.AppSettings {

	public class KVKDataSettingsBridge : IKVKDataSettings {
		protected readonly IOptionsSnapshot<KVKDataSettingsReader> optionsConfig;

		public KVKDataSettingsBridge(IOptionsSnapshot<KVKDataSettingsReader> optionsConfig) {
			this.optionsConfig = optionsConfig ?? throw new ArgumentNullException(nameof(optionsConfig));
		}

		public String APIKey  => this.optionsConfig.Value.APIKey;
	}
}
