import { Component, Input } from '@angular/core';
import { ArticleStore } from '../assets/data'
import { Article } from '../assets/article'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'app';
  articles = this.loadArticles();
  selectedArticle: Article

  onSelectedChanged(article: Article) {
    this.selectedArticle = article;
  }

  private loadArticles() {
    let store = new ArticleStore();

    return store.GetArticles();
  }
}
