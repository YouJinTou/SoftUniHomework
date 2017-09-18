import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutesModule } from './routes.module';
import { AppComponent } from './app.component';
import { Data } from './store/Data';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutesModule
  ],
  providers: [Data],
  bootstrap: [AppComponent]
})

export class AppModule { }
