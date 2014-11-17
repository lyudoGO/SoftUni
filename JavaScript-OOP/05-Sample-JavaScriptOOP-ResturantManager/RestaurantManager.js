function processRestaurantManagerCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
      if (!Object.create) {
        Object.prototype.create = function (proto) {
          function F() {};
          F.prototype = proto;
          return new F;
        };
      };
      
      this.prototype = Object.create(parent.prototype);
      this.prototype.constructor = this;
    };

    var METRIC_UNIT = {
        GRAMS: "g",
        MILLILITERS: "ml"
    };

    function isString(str) {
        return (typeof str === 'string');
    }

    var RestaurantEngine = (function () {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }

        var Restaurant = (function () {
            function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipes = [];
            };

            Restaurant.prototype = {
                getName: function() {
                    return this._name;
                },
                setName: function(name) {
                    if (!name || !isString(name)) {
                        throw new Error("The name is required.");
                    };
                    this._name = name;
                },
                getLocation: function() {
                    return this._location;
                },
                setLocation: function(location) {
                    if (!location || !isString(location)) {
                        throw new Error("The location is required.");
                    };
                    this._location = location;
                },
                addRecipe: function(recipe) {
                     this._recipes.push(recipe);
                },
                removeRecipe: function(recipe) {
                    var index = this._recipes.indexOf(recipe);
                    if (index > -1) {
                        this._recipes.splice(index, 1);
                    }
                },
                printRestaurantMenu: function() {
                    var str = "***** " + this.getName() + " - " + this.getLocation() + " *****\n";
                    if (this._recipes === null || this._recipes.length < 1) {
                        str += "No recipes... yet\n";
                    } else {

                        var categories = {};
                        categories["DRINKS"] = this._recipes.filter(function (recipe) {
                            return recipe instanceof  Drink;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["SALADS"] = this._recipes.filter(function (recipe) {
                            return recipe instanceof  Salad;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["MAIN COURSES"] = this._recipes.filter(function (recipe) {
                            return recipe instanceof  MainCourse;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        categories["DESSERTS"] = this._recipes.filter(function (recipe) {
                            return recipe instanceof  Dessert;
                        }).sort(function (a, b) {
                            return a.getName().localeCompare(b.getName());
                        });

                        for (var categorie in categories) {
                            if (categories[categorie].length > 0 && typeof(categories[categorie]) === 'object') {
                                str += "~~~~~ " + categorie + " ~~~~~\n";
                                for (var i = 0;  i < categories[categorie].length; i++) {
                                    str += categories[categorie][i].toString();
                                }
                            }
                        }
                    }

                    return str;
                }
            };

            return Restaurant;
        }());

        var Recipe = (function () {
            function Recipe(name, price, calories, quantity, timeToPrepare){
                if (this.constructor === Recipe) {
                    throw new Error("Cannot instantiate abstract class Recipe.");
                };
                this.setName(name);
                this.setPrice(price);
                this.setCalories(calories);
                this.setQuantity(quantity);
                this.setTimeToPrepare(timeToPrepare);
                this._unit = "";
            };

            Recipe.prototype.getName = function() {
                return this._name;
            }

            Recipe.prototype.setName = function(name) {
                if (!name || !isString(name)) {
                    throw new Error("The name is required.");
                };
                this._name = name;
            }

            Recipe.prototype.getPrice = function() {
                return this._price.toFixed(2);
            }

            Recipe.prototype.setPrice = function(price) {
                if (price < 0) {
                    throw new Error("The price must be positive.");
                };
                this._price = price;
            }

            Recipe.prototype.getCalories = function() {
                return this._calories;
            }

            Recipe.prototype.setCalories = function(calories) {
                if (calories < 0) {
                    throw new Error("The calories must be positive.");
                };
                this._calories = calories;
            }

            Recipe.prototype.getQuantity = function() {
                return this._quantity;
            }

            Recipe.prototype.setQuantity = function(quantity) {
                if (quantity < 0) {
                    throw new Error("The quantity must be positive.");
                };
                this._quantity = quantity;
            }

            Recipe.prototype.getTimeToPrepare = function() {
                return this._timeToPrepare;
            }

            Recipe.prototype.setTimeToPrepare = function(timeToPrepare) {
                if (timeToPrepare < 0) {
                    throw new Error("The timeToPrepare must be positive.");
                };
                this._timeToPrepare = timeToPrepare;
            }

            Recipe.prototype.getUnit = function() {
                return this._unit;
            }

            Recipe.prototype.toString = function() {
                var resultStr = "==  " + this.getName() + " == $" + this.getPrice() + "\n" +
                        "Per serving: " + this.getQuantity() + " " + this.getUnit() + ", " + 
                         this.getCalories() + " kcal" + "\n" +
                        "Ready in " + this.getTimeToPrepare() + " minutes";

                return resultStr;
            }
            
            return Recipe;
        }());

        var Drink = (function() {
            function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                Recipe.call(this, name, price, calories, quantity, timeToPrepare);
                if (this.getCalories() > 100) {
                    throw new Error("The calories in a drink must not be greater than 100.");
                };
                if (this.getTimeToPrepare() > 20) {
                    throw new Error("The time to prepare a drink must not be greater than 20 minutes.");
                };
                this._isCarbonated = isCarbonated;
                this._unit = METRIC_UNIT.MILLILITERS;
            }

            Drink.extends(Recipe);

            Drink.prototype.getIsCarbonated = function() {
                return this._isCarbonated;
            }

            Drink.prototype.toString = function() {
                var baseStr = Recipe.prototype.toString.call(this);
                var resultStr = "Carbonated: " + (this.getIsCarbonated() ? "yes" : "no");

                return baseStr + "\n" + resultStr + "\n";
            }

            return Drink;
        }());

        var Meal = (function() {
            function Meal(name, price, calories, quantity, timeToPrepare, isVegan) {
                if (this.constructor === Meal) {
                    throw new Error("Cannot instantiate abstract class Recipe.");
                };
                Recipe.call(this, name, price, calories, quantity, timeToPrepare);
                this._isVegan = isVegan;
                this._unit = METRIC_UNIT.GRAMS;
            }

            Meal.extends(Recipe);

            Meal.prototype.getIsVegan = function() {
                return this._isVegan;
            }

            Meal.prototype.toggleVegan = function() {
                this._isVegan = !this._isVegan;
            }

             Meal.prototype.toString = function () {
                var base = Recipe.prototype.toString.call(this);
                var isVegan = this.getIsVegan() ? "[VEGAN] " : "";

                return isVegan + base;
            }

            return Meal;
        }());

        var Dessert = (function() {
            function Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this._withSugar = true;
            }

            Dessert.extends(Meal);

            Dessert.prototype.getWithSugar = function() {
                return this._withSugar;
            }

            Dessert.prototype.toggleSugar = function() {
                this._withSugar = !this._withSugar;
            }

            Dessert.prototype.toString = function() {
                var base = Meal.prototype.toString.call(this);
                var withSugar = this.getWithSugar() ? "" : "[NO SUGAR] ";
              
                return withSugar + base + "\n";
            }

            return Dessert;
        }());

        var MainCourse = (function() {
            function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, isVegan);
                this._type = type;
            }

            MainCourse.extends(Meal);

            MainCourse.prototype.getType = function() {
                return this._type;
            }

            MainCourse.prototype.toString = function() {
                var base = Meal.prototype.toString.call(this);
                var resultStr = "Type: " + this.getType() + "\n";

                return base + "\n" + resultStr;
            }

            return MainCourse;
        }());

        var Salad = (function() {
            function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, true);
                this._containsPasta = containsPasta;
            }

            Salad.extends(Meal);

            Salad.prototype.getContainsPasta = function() {
                return this._containsPasta;
            }

            Salad.prototype.toString = function() {
                var base = Meal.prototype.toString.call(this);
                var resultStr = "Contains pasta: " + (this.getContainsPasta() ? "yes" : "no");

                return base + "\n" + resultStr + "\n";
            }

            return Salad;
        }());

        var Command = (function () {

            function Command(commandLine) {
                this._params = new Array();
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) { return true });

                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) { return true; });
                    self._params[split[0]] = split[1];
                });
            }

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function printAllRecipes() {
            var resultStr = "~~~~~ ALL RECIPES ~~~~~\n";
          for (var recipe in _recipes) {
            if (_recipes[recipe] instanceof Recipe) {
                resultStr += _recipes[recipe].toString();
            };
          };

            return resultStr;
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                case "PrintAllRecipes":
                    result = printAllRecipes(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------
/*
(function() {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function(line) {
            arr.push(line);
        }).on('close', function() {
            console.log(processRestaurantManagerCommands(arr));
        });
    }
})();*/
