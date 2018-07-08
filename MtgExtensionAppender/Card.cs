namespace MtgExtensionAppender
{
    /// <summary>
    /// This was created with the paste special shortcut. The original JSON was copied from the TappedOut.net api response 
    /// from in Chrome's network tab
    /// </summary>
    public class Card
    {
        public string image_large { get; set; }
        public string latest_set { get; set; }
        public float latest_release_date { get; set; }
        public float cube_average { get; set; }
        public string power_toughness { get; set; }
        public string tcgplayer_url { get; set; }
        public string[] activation_costs { get; set; }
        public string[] keywords { get; set; }
        public string cardhoarder_foil_url { get; set; }
        public float ck_price { get; set; }
        public float tcg_low_price { get; set; }
        public float tcg_avg_price { get; set; }
        public All_Printings[] all_printings { get; set; }
        public float cardhoarder_price_tix { get; set; }
        public int mtgo_foil_id { get; set; }
        public int flat_cost { get; set; }
        public bool is_basic_land { get; set; }
        public int canadian_hl_score { get; set; }
        public string ck_url { get; set; }
        public bool is_limitless { get; set; }
        public string cardhoarder_url { get; set; }
        public int pk { get; set; }
        public bool booster_exclude { get; set; }
        public string full_url { get; set; }
        public int mana_cost_converted { get; set; }
        public string updated { get; set; }
        public string tags { get; set; }
        public string rules { get; set; }
        public string printing { get; set; }
        public string wizards_id { get; set; }
        public bool tap_land { get; set; }
        public object[] tokens { get; set; }
        public int mtgo_id { get; set; }
        public bool foil { get; set; }
        public object mana_produced { get; set; }
        public object[][] price_data { get; set; }
        public string slug { get; set; }
        public string mana_cost { get; set; }
        public float cardhoarder_foil_price_tix { get; set; }
        public float ck_foil_price { get; set; }
        public string image_medium { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string image_small { get; set; }
        public string rarity { get; set; }
        public string cannonical_type { get; set; }
        public float tcg_high_price { get; set; }
        public string tla { get; set; }
        public string[] effective_cost { get; set; }
        public string wizards_url { get; set; }
        public string[] formats { get; set; }
        public string image_tiny { get; set; }
    }

    public class All_Printings
    {
        public string name { get; set; }
        public string url { get; set; }
        public object[] variations { get; set; }
        public string slug { get; set; }
        public string tla { get; set; } //The expansion name in a 3 letter code
        public string full_url { get; set; }
    }
}
