docker build -t doc-new-api-img .

docker tag doc-new-api-img registry.heroku.com/doc-new-api/web

docker push registry.heroku.com/doc-new-api/web

heroku container:release web -a doc-new-api