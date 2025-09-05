// Helpers/JsonOptions.cs
using System.Text.Json;
using System.Text.Json.Serialization;

using InventoryPurchaseOrderWeb.Converters;  // ここで名前空間を追加

namespace InventoryPurchaseOrderWeb.Utils
{
    public static class JsonOptions
    {
        public static readonly JsonSerializerOptions Default = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new DateTimeSpaceJsonConverter() } // 先ほど作ったカスタムコンバータ
        };
    }
}
