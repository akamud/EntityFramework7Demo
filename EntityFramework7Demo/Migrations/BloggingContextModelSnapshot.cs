using EntityFramework7Demo.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using System;

namespace EntityFramework7Demo.Migrations
{
    [ContextType(typeof(BloggingContext))]
    public class BloggingContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("EntityFramework7Demo.Models.Blog", b =>
                    {
                        b.Property<int>("BlogId")
                            .GenerateValueOnAdd();
                        b.Property<string>("Url");
                        b.Key("BlogId");
                    });
                
                builder.Entity("EntityFramework7Demo.Models.Post", b =>
                    {
                        b.Property<int>("BlogId");
                        b.Property<string>("Content");
                        b.Property<int>("PostId")
                            .GenerateValueOnAdd();
                        b.Property<string>("Title");
                        b.Key("PostId");
                    });
                
                builder.Entity("EntityFramework7Demo.Models.Post", b =>
                    {
                        b.ForeignKey("EntityFramework7Demo.Models.Blog", "BlogId");
                    });
                
                return builder.Model;
            }
        }
    }
}