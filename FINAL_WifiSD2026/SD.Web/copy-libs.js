const fs = require("fs");
const path = require("path");

function copy(src, dest) {
    const dir = path.dirname(dest);
    if (!fs.existsSync(dir)) {
        fs.mkdirSync(dir, { recursive: true });
    }
    fs.copyFileSync(src, dest);
    console.log(`✔ Kopiert: ${dest}`);
}

// Bootstrap
copy("node_modules/bootstrap/dist/css/bootstrap.css", "wwwroot/lib/bootstrap/dist/css/bootstrap.css");
copy("node_modules/bootstrap/dist/css/bootstrap.min.css", "wwwroot/lib/bootstrap/dist/css/bootstrap.min.css");

copy("node_modules/bootstrap/dist/css/bootstrap-grid.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-grid.css");
copy("node_modules/bootstrap/dist/css/bootstrap-grid.min.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-grid.min.css");

copy("node_modules/bootstrap/dist/css/bootstrap-reboot.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-reboot.css");
copy("node_modules/bootstrap/dist/css/bootstrap-reboot.min.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-reboot.min.css");

copy("node_modules/bootstrap/dist/css/bootstrap-utilities.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-utilities.css");
copy("node_modules/bootstrap/dist/css/bootstrap-utilities.min.css", "wwwroot/lib/bootstrap/dist/css/bootstrap-utilities.min.css");


copy("node_modules/bootstrap/dist/js/bootstrap.bundle.js", "wwwroot/lib/bootstrap/dist/js/bootstrap.bundle.js");
copy("node_modules/bootstrap/dist/js/bootstrap.bundle.min.js", "wwwroot/lib/bootstrap/dist/js/bootstrap.bundle.min.js");

/*   Requires entry:  

    "scripts": {
        "update-libs": "npm update && node copy-libs.js"
    }

    in package.json.

    Run it with: npm run update-libs
  */


// jQuery
copy("node_modules/jquery/dist/jquery.js", "wwwroot/lib/jquery/dist/jquery.js");
copy("node_modules/jquery/dist/jquery.min.js", "wwwroot/lib/jquery/dist/jquery.min.js");

// jquery-validation
copy("node_modules/jquery-validation/dist/jquery.validate.js", "wwwroot/lib/jquery-validation/dist/jquery.validate.js");
copy("node_modules/jquery-validation/dist/jquery.validate.min.js", "wwwroot/lib/jquery-validation/dist/jquery.validate.min.js");
copy("node_modules/jquery-validation/dist/additional-methods.js", "wwwroot/lib/jquery-validation/dist/additional-methods.js");
copy("node_modules/jquery-validation/dist/additional-methods.min.js", "wwwroot/lib/jquery-validation/dist/additional-methods.min.js");

fs.cpSync(
    "node_modules/jquery-validation/dist/localization",
    "wwwroot/lib/jquery-validation/dist/localization",
    { recursive: true }
);

// Globalize
copy("node_modules/globalize/dist/globalize.js", "wwwroot/lib/globalize/globalize.js");
copy("node_modules/globalize/dist/globalize/currency.js", "wwwroot/lib/globalize/globalize/currency.js");
copy("node_modules/globalize/dist/globalize/date.js", "wwwroot/lib/globalize/globalize/date.js");
copy("node_modules/globalize/dist/globalize/message.js", "wwwroot/lib/globalize/globalize/message.js");
copy("node_modules/globalize/dist/globalize/number.js", "wwwroot/lib/globalize/globalize/number.js");
copy("node_modules/globalize/dist/globalize/plural.js", "wwwroot/lib/globalize/globalize/plural.js");
copy("node_modules/globalize/dist/globalize/relative-time.js", "wwwroot/lib/globalize/globalize/relative-time.js");
copy("node_modules/globalize/dist/globalize/unit.js", "wwwroot/lib/globalize/globalize/unit.js");


// cldrjs
copy("node_modules/cldrjs/dist/cldr.js", "wwwroot/lib/cldrjs/cldr.js");
copy("node_modules/cldrjs/dist/cldr/event.js", "wwwroot/lib/cldrjs/cldr/event.js");
copy("node_modules/cldrjs/dist/cldr/supplemental.js", "wwwroot/lib/cldrjs/cldr/supplemental.js");

// CLDR-Daten
const cldrBase_de = "node_modules/cldr-data/main/de";
copy(`${cldrBase_de}/ca-gregorian.json`, "wwwroot/lib/cldr-data/main/de/ca-gregorian.json");
copy(`${cldrBase_de}/currencies.json`, "wwwroot/lib/cldr-data/main/de/currencies.json");
copy(`${cldrBase_de}/numbers.json`, "wwwroot/lib/cldr-data/main/de/numbers.json");
copy(`${cldrBase_de}/timeZoneNames.json`, "wwwroot/lib/cldr-data/main/de/timeZoneNames.json");

const cldrBase_de_AT = "node_modules/cldr-data/main/de-AT";
copy(`${cldrBase_de_AT}/ca-gregorian.json`, "wwwroot/lib/cldr-data/main/de-AT/ca-gregorian.json");
copy(`${cldrBase_de_AT}/currencies.json`, "wwwroot/lib/cldr-data/main/de-AT/currencies.json");
copy(`${cldrBase_de_AT}/numbers.json`, "wwwroot/lib/cldr-data/main/de-AT/numbers.json");
copy(`${cldrBase_de_AT}/timeZoneNames.json`, "wwwroot/lib/cldr-data/main/de-AT/timeZoneNames.json");

const cldrBase_en = "node_modules/cldr-data/main/en";
copy(`${cldrBase_en}/ca-gregorian.json`, "wwwroot/lib/cldr-data/main/en/ca-gregorian.json");
copy(`${cldrBase_en}/currencies.json`, "wwwroot/lib/cldr-data/main/en/currencies.json");
copy(`${cldrBase_en}/numbers.json`, "wwwroot/lib/cldr-data/main/en/numbers.json");
copy(`${cldrBase_en}/timeZoneNames.json`, "wwwroot/lib/cldr-data/main/en/timeZoneNames.json");


copy("node_modules/cldr-data/supplemental/likelySubtags.json", "wwwroot/lib/cldr-data/supplemental/likelySubtags.json");
copy("node_modules/cldr-data/supplemental/numberingSystems.json", "wwwroot/lib/cldr-data/supplemental/numberingSystems.json");
copy("node_modules/cldr-data/supplemental/timeData.json", "wwwroot/lib/cldr-data/supplemental/timeData.json");
copy("node_modules/cldr-data/supplemental/weekData.json", "wwwroot/lib/cldr-data/supplemental/weekData.json");

