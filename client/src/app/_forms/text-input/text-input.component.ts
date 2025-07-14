import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements ControlValueAccessor {
  @Input() label: string = '';
  @Input() type: string = 'text';

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {
    // No-op for now
  }

  registerOnChange(fn: any): void {
    // No-op for now
  }

  registerOnTouched(fn: any): void {
    // No-op for now
  }

  get control(): FormControl {
    return this.ngControl.control as FormControl;
  }
}
