import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, EventEmitter, HostListener, Output, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SearchFilter } from '../../@types';

@Component({
  selector: 'app-searchbar',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './searchbar.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchbarComponent {
  @ViewChild('myDialog') dialog!: ElementRef<HTMLDialogElement>;
  @ViewChild('dialogContainer') dialogContainer!: ElementRef<HTMLDivElement>
  private isDialogOpen: boolean = false;

  searchFilter: SearchFilter = {
    query: '',
    location: '',
    fullTimeOnly: false
  };
  @Output() queryEvent = new EventEmitter<SearchFilter>();

  emitFilterEvent() {
    this.queryEvent.emit(this.searchFilter);
    this.closeDialog();
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: Event): void {
    const targetNode = event.target as HTMLElement;

    if (this.isDialogOpen &&
      this.dialog.nativeElement.contains(targetNode) &&
      !this.dialogContainer.nativeElement.contains(targetNode)) {
      this.dialog.nativeElement.close();
    }
  }

  closeDialog() {
    this.isDialogOpen = false;
    this.dialog.nativeElement.close();
  }

  openDialog() {
    this.isDialogOpen = true;
    this.dialog.nativeElement.showModal();
  }
}
