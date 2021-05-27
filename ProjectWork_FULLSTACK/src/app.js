const express = require("express");
const session = require("express-session");
const morgan = require("morgan");
const bcrypt = require("bcrypt");
const app = express();
const routes = require("./api/router");
const cors = require("cors");
const mongoose = require("mongoose");
const hbs = require("express-handlebars");
const passport = require("passport");
const localStrategy = require("passport-local").Strategy;
const errorHandlers = require("./errors");
const path = require("path");

mongoose.connect("mongodb://localhost:27017/its21_PLCProjectV1", {
    useNewUrlParser: true,
    useUnifiedTopology: true,
});
mongoose.set("debug", true);

const UserSchema = new mongoose.Schema({
    username: {
        type: String,
        required: true,
    },
    password: {
        type: String,
        required: true,
    },
});

const User = mongoose.model("User", UserSchema);
app.use(express.urlencoded({extended: false}));
app.use(express.json());
app.use(
    session({secret: "verygoodsecret", resave: false, saveUninitialized: true})
);
// Passport.js
app.use(passport.initialize());
app.use(passport.session());
//Middleware
app.engine("hbs", hbs({extname: ".hbs"}));
app.set("view engine", "hbs");
app.get("/**/*.html", isLoggedIn);
app.use(express.static(path.join(__dirname, "./public")));

// error handling
app.use(errorHandlers);
app.use(cors());

//accesso file
app.use(morgan("tiny"));
app.use("/api", routes);

//PASSPORT
passport.serializeUser(function (user, done) {
    done(null, user.id);
});

passport.deserializeUser(function (id, done) {
    User.findById(id, function (err, user) {
        done(err, user);
    });
});

passport.use(
    new localStrategy(function (username, password, done) {
        User.findOne({username: username}, function (err, user) {
            if (err) return done(err);
            if (!user)
                return done(null, false, {message: "Incorrect username."});

            bcrypt.compare(password, user.password, function (err, res) {
                if (err) return done(err);
                if (res === false)
                    return done(null, false, {message: "Incorrect password."});
                console.log("!!!");
                return done(null, user);
            });
        });
    })
);

// LOGED
function isLoggedIn(req, res, next) {
    console.log("check");
    if (req.isAuthenticated()) {
        console.log("authenticated");
        return next();
    }
    res.redirect("/login");
}

function isLoggedOut(req, res, next) {
    console.log("logout");
    if (!req.isAuthenticated()) return next();
    res.redirect("/html/index.html");
}

// ROUTES
app.get("/", isLoggedIn, (req, res, next) => {
    res.redirect("/html/index.html");
});

app.get("/login", isLoggedOut, (req, res, next) => {
    const response = {
        title: "Login",
        error: req.query.error,
    };
    res.render("login", response);
});

app.post(
    "/login",
    passport.authenticate("local", {
        successRedirect: "/",
        failureRedirect: "/login?error=true",
    })
);

// Setup our admin user
app.get("/setup", async (req, res, next) => {
    const exists = await User.exists({username: "admin"});

    if (exists) {
        res.redirect("/login");
        return;
    }

    bcrypt.genSalt(10, function (err, salt) {
        if (err) return next(err);
        bcrypt.hash("pass", salt, function (err, hash) {
            if (err) return next(err);

            const newAdmin = new User({
                username: "admin",
                password: hash,
            });

            newAdmin.save();

            res.redirect("/login");
        });
    });
});

module.exports = app;
