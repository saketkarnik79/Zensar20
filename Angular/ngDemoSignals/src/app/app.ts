import { Component, signal, computed, effect, WritableSignal, Signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // Step 1: Define Signals
  protected readonly title: WritableSignal<string> = signal('Demo Signals');
  count: WritableSignal<number> = signal(0);

  //Step 2: Define computed signals
  doubleCount: Signal<number> = computed(()=> this.count() * 2);

  //Step 3: Define effects
  constructor(){
    effect(() => {
      console.log(`Count changed: ${this.count()}`);
    });
  }

  //Step 4: Method to update the signals
  increment(){
    this.count.update(c => c + 1);
  }

  decrement(){
    this.count.update(c => c - 1);
  }

  reset(){
    this.count.set(0);
  }
}
