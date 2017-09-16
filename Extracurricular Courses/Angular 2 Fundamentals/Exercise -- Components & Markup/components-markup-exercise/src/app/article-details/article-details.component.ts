import { Component, OnInit, Input } from '@angular/core';
import { Article } from '../../assets/article'

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent {
  @Input() article: Article
  shouldShowImage: boolean;
  descriptionFontSize: number;

  private lastTitle: string
  private readMoreCounter: number;
  private lastDescription: string;
  private shouldShowReadMoreButton: boolean;

  constructor() {
    this.readMoreCounter = 0;
    this.shouldShowReadMoreButton = this.ShouldShowReadMoreButton;
    this.descriptionFontSize = 12;
  }

  get ShouldShowReadMoreButton(): boolean {
    if (this.article === null || this.article === undefined) {
      return false;
    }

    if (this.article.description.length <= 250) {
      return false;
    }

    this.limitDescription();

    return this.shouldShowReadMoreButton;
  }

  set ShouldShowReadMoreButton(value: boolean) {
    this.shouldShowReadMoreButton = value;
  }

  onToggleImage() {
    this.shouldShowImage = !this.shouldShowImage;
  }

  changeFont(isIncrease: boolean) {
    let lowerBound = 8;
    let upperBound = 20;
    
    if (isIncrease) {
      if (this.descriptionFontSize + 1 > upperBound) {
        this.descriptionFontSize = upperBound;
      } else {
        this.descriptionFontSize++;
      }
    } else {
      if (this.descriptionFontSize - 1 < lowerBound) {
        this.descriptionFontSize = lowerBound;
      } else {
        this.descriptionFontSize--;
      }
    }
  }

  limitDescription() {
    if (!this.lastTitle || this.lastTitle === this.article.title) {
      this.readMoreCounter++;
    } else {
      this.readMoreCounter = 1;
    }

    this.lastTitle = this.article.title;
    this.lastDescription = this.readMoreCounter == 1 ? this.article.description : this.lastDescription;
    let limit = this.readMoreCounter * 250;
    this.article.description = this.lastDescription.substring(0, limit);
    this.ShouldShowReadMoreButton = this.article.description.length < this.lastDescription.length;
  }
}
