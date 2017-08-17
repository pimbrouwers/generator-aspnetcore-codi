var Generator = require('yeoman-generator');

module.exports = class extends Generator {    
    constructor(args, opts) {
        super(args, opts);

        this.argument('appname', { type: String, required: true });
    }
    
    writing(){
        //config file(s)
        this.fs.copyTpl(this.templatePath('_gitignore'), this.destinationPath('.gitignore'));

        //project file
        this.fs.copyTpl(this.templatePath('AspNetCoreCodi.csproj'), this.destinationPath(this.options.appname + '.csproj'));

        //app files
        this.fs.copyTpl(this.templatePath('src/**'), this.destinationPath('.'), { appName: this.options.appname });
    }

    install(){
        //dotnet restore
        this.spawnCommand('dotnet', ['restore']);
    }
};
