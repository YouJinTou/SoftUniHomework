import { Component, OnInit } from '@angular/core';
import { ArticleStore } from '../../assets/data'

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})

export class ArticleListComponent {  
  articles = this.loadArticles();

  private loadArticles() {
    let store = new ArticleStore();

    return store.GetArticles();
  }
}
