import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Article } from '../../assets/article'

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})

export class ArticleListComponent {
  @Input() articles: Article[];
  @Output() selectedChanged = new EventEmitter<Article>();

  onArticleChanged(article: Article) {
    this.selectedChanged.emit(article);
  }
}
