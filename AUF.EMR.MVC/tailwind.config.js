module.exports = {
    content: ["./Views/**/*,{cshtml,razor}", "./wwwroot/js/**/*.js", './wwwroot/lib/flowbite/**/*.js', ],
    theme: {
        extend: {
            colors: {
                primary: { "50": "#accb8f" }
            }
        },
    },
    plugins: [
        require('flowbite/plugin')
    ]
}