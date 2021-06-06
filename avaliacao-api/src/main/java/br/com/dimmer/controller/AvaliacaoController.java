package br.com.dimmer.controller;

import java.util.List;
import java.util.concurrent.ExecutionException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import br.com.dimmer.domain.Avaliacao;
import br.com.dimmer.service.IAvaliacaoService;

@RestController
@RequestMapping("/avaliacao")
public class AvaliacaoController {
	
	@Autowired
	private IAvaliacaoService avaliacaoService;	
	
	@GetMapping	
	public ResponseEntity<List<Avaliacao>> listar() throws InterruptedException {		
		return ResponseEntity.ok(avaliacaoService.listar());
	}
	
	@GetMapping("/{codigo}")	
	public ResponseEntity<Avaliacao> buscar(@PathVariable long codigo) throws InterruptedException, ExecutionException {		
		return ResponseEntity.ok(avaliacaoService.buscarPor(codigo));
	}
	
	@PostMapping
	public ResponseEntity<Avaliacao> criar(@RequestBody Avaliacao avaliacao) throws InterruptedException, ExecutionException {
		return ResponseEntity.ok(avaliacaoService.inserir(avaliacao));
	}
}
